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
    public class FirmaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private VDL vdl = new VDL();
        // GET: Firma
        public ActionResult Index()
        {
            return View(db.Firmas.Where(q => q.ApplicationUser.UserName == User.Identity.Name).ToList());
        }

        // GET: Firma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firmas.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // GET: Firma/Create
        public ActionResult Create()
        {
            var vdlist = vdl.GetVDL();

            var Slvdlist = new SelectList(vdlist);
            ViewBag.Vdl = Slvdlist;
            return View();
        }

        // POST: Firma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,YetkiliStatu,YetkiliAdSoyad,Tel,Tel2,Tel3,Email,Fax,Il,Ilce,Adres")] Firma firma, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();
                firma.ApplicationUserId = user.Id;
                firma.VergiDairesi = form["VergiDairesi"];
                db.Firmas.Add(firma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firma);
        }

        // GET: Firma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firmas.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // POST: Firma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,YetkiliStatu,YetkiliAdSoyad,Tel,Tel2,Tel3,Email,Fax,Il,Ilce,Adres,VergiDairesi,ApplicationUserId")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firma);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                db.Firmas.Remove(db.Firmas.FirstOrDefault(q => q.Id == id));
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
