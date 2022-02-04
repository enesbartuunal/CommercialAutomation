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
    public class BankaHesabıController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Banka
        public ActionResult Index()
        {
            var bankas = db.Bankas.Include(b => b.Firma).Include(b => b.Musteri).Where(q => q.ApplicationUser.UserName == User.Identity.Name);

            return View(bankas.ToList());
        }

        // GET: Banka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banka banka = db.Bankas.Find(id);
            if (banka == null)
            {
                return HttpNotFound();
            }
            return View(banka);
        }

        // GET: Banka/Create
        public ActionResult Create()
        {
            var musteriList = db.Musteris.Where(q => q.ApplicationUser.UserName == User.Identity.Name);
            var firmaList = db.Firmas.Where(q => q.ApplicationUser.UserName == User.Identity.Name);

            ViewBag.mList = new SelectList(musteriList, "Id", "Ad");
            ViewBag.fList = new SelectList(firmaList, "Id", "Ad");

            return View();
        }

        // POST: Banka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IBAN")] Banka banka, FormCollection form)
        {
            string Mname = form["MName"];
            string MId = form["MId"];
            string Fname = form["FName"];
            string FId = form["FId"];
            if (MId == null && FId == null)
            {
                ViewBag.Message = "Lütfen Müşteri veya Firma bilgilerini seçiniz!";
            }
            else
            {
                ViewBag.Message = "";
                if (ModelState.IsValid)
                {
                    if (FId != "")
                        banka.FirmaId = Convert.ToInt32(FId);
                    if (MId != "")
                        banka.MusteriId = Convert.ToInt32(MId);
                    var IBAnTrEkle = "" + banka.IBAN;
                    banka.IBAN = IBAnTrEkle;
                    var user = new ApplicationUser();
                    user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();
                    banka.ApplicationUserId = user.Id;
                    db.Bankas.Add(banka);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            var musteriList = db.Musteris.Where(q => q.ApplicationUser.UserName == User.Identity.Name);
            var firmaList = db.Firmas.Where(q => q.ApplicationUser.UserName == User.Identity.Name);
            ViewBag.mList = new SelectList(musteriList, "Id", "Ad");
            ViewBag.fList = new SelectList(firmaList, "Id", "Ad");

            return View(banka);
        }

        // GET: Banka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banka banka = db.Bankas.Find(id);
            if (banka == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmaId = new SelectList(db.Firmas, "Id", "Ad", banka.FirmaId);
            ViewBag.MusteriId = new SelectList(db.Musteris, "Id", "Ad", banka.MusteriId);
            return View(banka);
        }

        // POST: Banka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IBAN,FirmaId,MusteriId,ApplicationUserId")] Banka banka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmaId = new SelectList(db.Firmas, "Id", "Ad", banka.FirmaId);
            ViewBag.MusteriId = new SelectList(db.Musteris, "Id", "Ad", banka.MusteriId);
            return View(banka);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                db.Bankas.Remove(db.Bankas.FirstOrDefault(q => q.Id == id));
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(id);
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
