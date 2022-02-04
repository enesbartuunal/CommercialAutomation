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
    public class GiderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gider
        public ActionResult Index()
        {
            return View((db.Giders.Where(q => q.ApplicationUser.UserName == User.Identity.Name).ToList()));
        }

        // GET: Gider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gider gider = db.Giders.Find(id);
            if (gider == null)
            {
                return HttpNotFound();
            }
            return View(gider);
        }

        // GET: Gider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Notlar,Tutar")] Gider gider,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();
                gider.ApplicationUserId = user.Id;
                gider.KasaId = user.KasaId;
                var date = form["Tarih"];
                var date2 = Convert.ToDateTime(date);
                gider.Tarih = date2;
                db.Giders.Add(gider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KasaId = new SelectList(db.Kasas, "Id", "Id", gider.KasaId);
            return View(gider);
        }

        // GET: Gider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gider gider = db.Giders.Find(id);
            if (gider == null)
            {
                return HttpNotFound();
            }
           
            return View(gider);
        }

        // POST: Gider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Notlar,Tarih,Tutar,KasaId,ApplicationUserId")] Gider gider)
        {
            if (ModelState.IsValid)
            {
                var date = gider.Tarih;
                var date2 = Convert.ToDateTime(date);
                gider.Tarih = date2;
                db.Entry(gider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(gider);
        }

        // GET: Gider/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                db.Giders.Remove(db.Giders.FirstOrDefault(q => q.Id == id));
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
