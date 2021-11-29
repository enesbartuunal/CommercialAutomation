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
    public class KasaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kasa
        public ActionResult Index()
        {
          var user=  db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();

            var list=db.Kasas.Where(q => q.Id == user.KasaId).ToList();
           
            return View(list);
        }

        // GET: Kasa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kasa kasa = db.Kasas.Find(id);
            if (kasa == null)
            {
                return HttpNotFound();
            }
            return View(kasa);
        }

        // GET: Kasa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Kasa kasa)
        {
            if (ModelState.IsValid)
            {
                db.Kasas.Add(kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kasa);
        }

        // GET: Kasa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kasa kasa = db.Kasas.Find(id);
            if (kasa == null)
            {
                return HttpNotFound();
            }
            return View(kasa);
        }

        // POST: Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Kasa kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kasa);
        }

        // GET: Kasa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kasa kasa = db.Kasas.Find(id);
            if (kasa == null)
            {
                return HttpNotFound();
            }
            return View(kasa);
        }

        // POST: Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kasa kasa = db.Kasas.Find(id);
            db.Kasas.Remove(kasa);
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
