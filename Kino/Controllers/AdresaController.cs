using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kino.Models;
using Microsoft.AspNetCore.Authorization;
using Kino.Helper;

namespace Kino.Controllers
{
    [Autorizacija("Uposlenik")]

    public class AdresaController : Controller
    {
        public IActionResult DodajForm()
        {
            MojDbContext db = new MojDbContext();
            AdresaEditVM vm = new AdresaEditVM();
            vm.Grad = db.Grad.Select(o => new SelectListItem(o.Naziv, o.GradID.ToString())).ToList();
            return View("UrediForm",vm);
        }
        public IActionResult UrediForm(int AdresaID)
        {
            if (AdresaID == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            MojDbContext db = new MojDbContext();
            Adresa ad = db.Adresa.Find(AdresaID);
            if (ad == null)
            {
                return RedirectToAction(nameof(Index));
            }
            AdresaEditVM vm = new AdresaEditVM();
            vm.Grad= db.Grad.Select(o => new SelectListItem(o.Naziv, o.GradID.ToString())).ToList();
            vm.GradId = ad.GradId;
            vm.AdresaID = ad.AdresaID;
            vm.NazivUlice = ad.NazivUlice;
            return View("UrediForm", vm);
        }
        public bool DaLiPostoji(string Naziv)
        {
            MojDbContext db = new MojDbContext();
            List<Adresa> d = db.Adresa.ToList();
            foreach (var dd in d)
            {
                if (string.Compare(Naziv, dd.NazivUlice) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public IActionResult Snimi(AdresaEditVM ad)
        {
            MojDbContext db = new MojDbContext();
            Adresa a;
            if (ad.AdresaID == 0)
            {
                a = new Adresa();
                db.Add(a);
            }
            else
            {
                a = db.Adresa.Find(ad.AdresaID);
                a.AdresaID = ad.AdresaID;
                if (DaLiPostoji(ad.NazivUlice))
                {
                    return Redirect("/Adresa/?poruka=Adresa je vec pohranjena u bazu");
                }
            }
            a.GradId = ad.GradId;
            a.NazivUlice = ad.NazivUlice;
            db.SaveChanges();
            db.Dispose();
            return Redirect("/Adresa/?poruka=Uspjesno ste pohranili podatke za adresu");
        }
        public IActionResult Index(string Poruka)
        {
            MojDbContext db = new MojDbContext();
            List<Adresa> ad = db.Adresa.Include(s => s.Grad).ToList();
            ViewData["Adrese"] = Poruka;
                return View(ad);
        }
        public IActionResult Obrisi(int AdresaId)
        {
            MojDbContext db = new MojDbContext();
            Adresa d = db.Adresa.Where(s => s.AdresaID == AdresaId).FirstOrDefault();
            if (d == null)
            {
                return Content("Adresa ne postoji");
            }
            db.Remove(d);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(Index));
        }
    }
}