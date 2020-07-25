using System;
using System.Collections.Generic;
using System.Linq;
using Kino.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kino.Helper;

namespace Kino.Controllers
{
    [Autorizacija("Uposlenik")]
    public class GradController : Controller
    {
        public IActionResult DodajForm()
        {
            MojDbContext db = new MojDbContext();  
            GradEditVM model = new GradEditVM();
            model.Drzava = db.Drzava.Select(o => new SelectListItem(o.Naziv, o.DrzavaID.ToString())).ToList();
            return View("UrediForm", model);
        }
        public IActionResult UrediForm(int GradId)
        {
            if(GradId == 0)
                return RedirectToAction(nameof(Index));

            MojDbContext db = new MojDbContext();
            Grad g = db.Grad.Find(GradId);
            if (g == null)
            {
                return RedirectToAction(nameof(Index));
            }
            GradEditVM model = new GradEditVM();
            model.Drzava = db.Drzava.Select(o => new SelectListItem(o.Naziv, o.DrzavaID.ToString())).ToList();
            model.DrzavaID = g.DrzavaID;
            model.Id = g.GradID;
            model.Naziv = g.Naziv;
            model.PostanskiBroj = g.PostanskiBroj;

            return View("UrediForm", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Snimi(GradEditVM input)
        {
            MojDbContext db = new MojDbContext();
            Grad g;
            if (input.Id == 0)
            {
                g = new Grad();
                db.Add(g);
            }
            else
            {
                g = db.Grad.Find(input.Id);     
                g.GradID = input.Id;
                if (DaLiPostoji(input.Naziv))
                {
                    return Redirect("/Grad/?poruka=Grad je vec pohranjen u bazu");
                }
            }
            
            g.DrzavaID = input.DrzavaID;
            g.Naziv = input.Naziv;
            g.PostanskiBroj = input.PostanskiBroj;
           
            db.SaveChanges();
            db.Dispose();
            return Redirect("/Grad/?poruka=Uspjesno ste pohranili podatke za grad");
        }
       
        public bool DaLiPostoji(string Naziv)
        {
            MojDbContext db = new MojDbContext();
            List<Grad> d = db.Grad.ToList();
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
            List<Grad> gradovi = db.Grad.
                Include(s=>s.Drzava)
                .ToList();
            ViewData["gradovi-kljuc"] = Poruka;
            return View(gradovi);
        }
        public IActionResult Obrisi(int GradId)
        {
            MojDbContext db = new MojDbContext();
            Grad g = db.Grad.Where(x => x.GradID == GradId).FirstOrDefault();
            if (g == null)
            {
                return Content("Grad ne postoji");
            }
            db.Remove(g);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(Index));
        }
    }
}