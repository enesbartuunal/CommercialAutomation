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
    public class StokController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stok
        public ActionResult Index()
        {
            var list = db.Stoks.Include(f=>f.Urun).Where(q => q.ApplicationUser.UserName == User.Identity.Name);
            return View(list.ToList());
        }

        // GET: Stok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        // GET: Stok/Create
        public ActionResult Create()
        {
            var user = new ApplicationUser();
            user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();

            var list=db.Uruns.Where(q => q.ApplicationUserId == user.Id).ToList();

            var stoklist = db.Stoks.Where(q => q.ApplicationUserId == user.Id).ToList();

            var list2 = list.Where(q => stoklist.Any(a => a.UrunId == q.Id)).ToList();

            var list3 = list.Except(list2).ToList();      
                        


            ViewBag.UrunList = new SelectList(list3, "Id", "UrunAd");

            return View();
        }

        // POST: Stok/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Miktar,UrunId")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();
                stok.ApplicationUserId = user.Id;
                db.Stoks.Add(stok);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stok);
        }

        // GET: Stok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = new ApplicationUser();
            user = db.Users.Where(q => q.UserName == User.Identity.Name).FirstOrDefault();

            var list = db.Uruns.Where(q => q.ApplicationUserId == user.Id);

            ViewBag.UrunList = new SelectList(list, "Id", "UrunAd");
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        // POST: Stok/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Miktar,UrunId,ApplicationUserId")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stok).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stok);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                db.Stoks.Remove(db.Stoks.FirstOrDefault(q => q.Id == id));
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
