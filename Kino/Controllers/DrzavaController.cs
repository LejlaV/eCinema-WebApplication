using Kino.Helper;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Kino.Controllers
{
    [Autorizacija("Uposlenik")]
    public class DrzavaController : Controller
    {
        public IActionResult DodajForm()
        {
            DrzavaEditVM vm = new DrzavaEditVM();
            return View("UrediDodajForm", vm);
        }
        public IActionResult UrediFormu(int DrzavaID)
        {
            if (DrzavaID == 0)
            {
                return RedirectToAction(nameof(Index));
            }
          
            MojDbContext db = new MojDbContext();
            Drzava d = db.Drzava.Find(DrzavaID); ;
            if (d == null)
            {
                return RedirectToAction(nameof(Index));
            }

            DrzavaEditVM dev = new DrzavaEditVM();
            dev.DrzavaID = d.DrzavaID;
            dev.Naziv = d.Naziv;
            dev.Oznaka = d.Oznaka;
            return View("UrediDodajForm", dev);
        }
        public IActionResult Snimi(DrzavaEditVM vm)
        {
            MojDbContext db = new MojDbContext();
            Drzava d;
            if (vm.DrzavaID == 0)
            {
                d = new Drzava();
                db.Add(d);
            }
            else
            {
                d = db.Drzava.Find(vm.DrzavaID);
                d.DrzavaID = vm.DrzavaID;
                if (DaLiPostoji(vm.Naziv))
                {
                    return Redirect("/Drzava/?poruka=Drzava je vec pohranjena u bazu");
                }
            }
            d.Naziv = vm.Naziv;
            d.Oznaka = vm.Oznaka;
            db.SaveChanges();
            db.Dispose();
            return Redirect("/Drzava/?poruka=Uspjesno ste pohranili podatke za drzavu");
        }
        public bool DaLiPostoji(string Naziv)
        {
            MojDbContext db = new MojDbContext();
            List<Drzava> d = db.Drzava.ToList();
            foreach (var dd in d)
            {
                if (string.Compare(Naziv, dd.Naziv) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public IActionResult Index(string Poruka)
        {
            MojDbContext db = new MojDbContext();
           List<Drzava>podaci = db.Drzava.ToList();
            ViewData["poruka-kljuc"] = Poruka;
            return View(podaci);
        }
        public ActionResult Obrisi(int DrzavaId)
        {
            MojDbContext db = new MojDbContext();
            Drzava d = db.Drzava.Where(x => x.DrzavaID == DrzavaId).FirstOrDefault();
            if (d == null)
            {
                return Content("Drzava ne postoji");
            }
            db.Remove(d);

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(Index));
        }
    }
}