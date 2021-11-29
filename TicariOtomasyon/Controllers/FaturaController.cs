using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models;


namespace TicariOtomasyon.Controllers
{
    [Authorize]
    public class FaturaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private VDL vdl = new VDL();
        // GET: Fatura
        [Authorize]
        public ActionResult Index()
        {
            var faturas = db.Faturas.Where(q => q.ApplicationUser.UserName == User.Identity.Name).ToList();
            return View(faturas.ToList());
        }

        // GET: Fatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }

        // GET: Fatura/Create
        public ActionResult Create()
        {
            var muslist = db.Musteris.Where(q => q.ApplicationUser.UserName == User.Identity.Name).Select(q => new { q.Id, q.Ad }).ToList();
            var firmalist = db.Firmas.Where(q => q.ApplicationUser.UserName == User.Identity.Name).Select(q => new { q.Id, q.Ad }).ToList();
            var MFListesi = muslist.Concat(firmalist).ToList();

            ViewBag.MFList = new SelectList(MFListesi, "Id", "Ad");

            var vdlist = vdl.GetVDL();
            var Slvdlist = new SelectList(vdlist);
            ViewBag.Vdl = Slvdlist;
            
            var urunlist = db.Uruns.Where(q => q.ApplicationUser.UserName == User.Identity.Name).ToList();
            ViewBag.UrunList = urunlist;

            return View();
        }

        // POST: Fatura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Seri,SıraNo,Tarih,Saat,VergiDairesi,TeslimAlan,TeslimEden,Fiyat,Miktar,MiktarCins,Tutar")] Fatura fatura, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();
                fatura.ApplicationUserId = user.Id;
                fatura.KasaId = user.KasaId;
                fatura.Alici = form["Alici"];

                db.Faturas.Add(fatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fatura);
        }

        // GET: Fatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatura fatura = db.Faturas.Find(id);
            if (fatura == null)
            {
                return HttpNotFound();
            }

            return View(fatura);
        }

        // POST: Fatura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Seri,SıraNo,Tarih,Saat,VergiDairesi,Alici,TeslimAlan,TeslimEden,Fiyat,Miktar,MiktarCins,Tutar,KasaId,ApplicationUserId")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fatura);
        }

        // Post: Fatura/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                db.Faturas.Remove(db.Faturas.FirstOrDefault(q => q.Id == id));
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(id);
        }

        [HttpGet]
        public JsonResult GetVD(int id, string ad)
        {
            var Firma = db.Firmas.Where(x => x.Id == id && x.Ad == ad).FirstOrDefault();
            var Musteri = db.Musteris.Where(q => q.Id == id && q.Ad == ad).FirstOrDefault();

            if (Firma == null)
            {
                var sonuc = Musteri;
                string sonucJson = JsonConvert.SerializeObject(sonuc); 
                return Json(sonucJson,JsonRequestBehavior.AllowGet);
            }
            else if (Musteri == null)
            {
                var sonuc = Firma;
                string sonucJson = JsonConvert.SerializeObject(sonuc);
                return Json(sonucJson, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
