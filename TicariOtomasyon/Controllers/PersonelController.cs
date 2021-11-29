using Nancy.Responses;
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
    public class PersonelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personel
        public ActionResult Index()
        {
            var list = db.Personels.Where(q => q.ApplicationUser.UserName == User.Identity.Name);
            return View(list.ToList());
        }

        // GET: Personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,Tel,Tc,Email,Görev,Il,Ilce,Adres")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();
                personel.ApplicationUserId = user.Id;
                db.Personels.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personel);
        }

        // GET: Personel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,Tel,Tc,Email,Görev,Il,Ilce,Adres,ApplicationUserId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personel);
        }


        // POST: Personel/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {

            try
            {
                db.Personels.Remove(db.Personels.FirstOrDefault(q => q.Id == id));
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
