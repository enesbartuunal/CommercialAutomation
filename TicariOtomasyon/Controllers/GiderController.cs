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
            var giders = db.Giders.Include(g => g.Kasa);
            return View(giders.ToList());
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
            ViewBag.KasaId = new SelectList(db.Kasas, "Id", "Id");
            return View();
        }

        // POST: Gider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Elektrik,Su,Dogalgaz,Internet,Maas,Extra,Notlar,Ay,Yil,KasaId,ApplicationUserId")] Gider gider)
        {
            if (ModelState.IsValid)
            {
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
            ViewBag.KasaId = new SelectList(db.Kasas, "Id", "Id", gider.KasaId);
            return View(gider);
        }

        // POST: Gider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Elektrik,Su,Dogalgaz,Internet,Maas,Extra,Notlar,Ay,Yil,KasaId,ApplicationUserId")] Gider gider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KasaId = new SelectList(db.Kasas, "Id", "Id", gider.KasaId);
            return View(gider);
        }

        // GET: Gider/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Gider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gider gider = db.Giders.Find(id);
            db.Giders.Remove(gider);
            db.SaveChanges();
            return RedirectToAction("Index");
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
