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
    public class MusteriController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private VDL vdl = new VDL();
        // GET: Musteri
        public ActionResult Index()
        {
            var list = db.Musteris.Where(q => q.ApplicationUser.UserName == User.Identity.Name);
            return View(list.ToList());
        }

        // GET: Musteri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteris.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: Musteri/Create
        public ActionResult Create()
        {
            var vdlist = vdl.GetVDL();

            var Slvdlist = new SelectList(vdlist);
            ViewBag.Vdl = Slvdlist;
            return View();
        }

        // POST: Musteri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,Tel,Tel2,Tc,Email,Il,Ilce,Adres")] Musteri musteri, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();
                musteri.ApplicationUserId = user.Id;
                musteri.VergiDairesi = form["VergiDairesi"];
                db.Musteris.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteri);
        }

        // GET: Musteri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteris.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            var vdlist = vdl.GetVDL();
            var Slvdlist = new SelectList(vdlist);
            ViewBag.Vdl = Slvdlist;
            return View(musteri);
        }

        // POST: Musteri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,Tel,Tel2,Tc,Email,Il,Ilce,Adres,VergiDairesi,ApplicationUserId")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteri);
        }




        // POST: Musteri/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                db.Musteris.Remove(db.Musteris.FirstOrDefault(q => q.Id == id));
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
