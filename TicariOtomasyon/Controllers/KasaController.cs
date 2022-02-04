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
            var kasa = list.Where(q => q.Tarih == DateTime.Today).FirstOrDefault();
            if (kasa==null)
            {
                kasa = new Kasa(); 
                kasa.Tarih = DateTime.Today;
                kasa.Tutar = 0;
                db.Kasas.Add(kasa);
                db.SaveChanges();
            }

            var faturas = db.Faturas.Where(w => w.TarihSaat.Day== kasa.Tarih.Day&& w.TarihSaat.Month == kasa.Tarih.Month&& w.TarihSaat.Year == kasa.Tarih.Year && w.ApplicationUserId==user.Id).ToList();

            var giders = db.Giders.Where(e => e.Tarih == kasa.Tarih&&e.ApplicationUserId==user.Id).ToList();

            //var faturatable = faturas.Select(q => new { Seri=q.Seri,Tutar= q.Tutar });
            //var gidertable = giders.Select(e => new { Notlar=e.Notlar,Tutar= e.Tutar });

            ViewBag.fatura = faturas;
            ViewBag.gider = giders;
           
            kasa.Tutar = faturas.Select(x => x.Tutar).Sum()-giders.Select(q=>q.Tutar).Sum();

            ViewBag.kasa = kasa.Tutar;
            return View(kasa);
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
