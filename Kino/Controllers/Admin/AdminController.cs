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
using Rotativa.AspNetCore;

namespace Kino.Controllers
{
    // [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public IActionResult ListaKorisnika()
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            var imePrezime = db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Ime).FirstOrDefault() + " " + db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Prezime).FirstOrDefault();
            var Username = db.Korisnici.Where(y => y.UlogaID == 1 && k.KorisnikID == y.KorisnikID).Select(y => y.UserName).FirstOrDefault();
            
            AdminVM n = new AdminVM { ImePrezime = imePrezime, UserName = Username };
            return View(n);
        }
        public IActionResult Lokacija()
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            var imePrezime = db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Ime).FirstOrDefault() + " " + db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Prezime).FirstOrDefault();
            var Username = db.Korisnici.Where(y => y.UlogaID == 1 && k.KorisnikID == y.KorisnikID).Select(y => y.UserName).FirstOrDefault();
            AdminVM n = new AdminVM { ImePrezime = imePrezime, UserName = Username };
            return View(n);
        }
        public IActionResult OduzmiPermisije(int KorisnikID)
        {
            MojDbContext db = new MojDbContext();
            var korisnik = db.Korisnici.Where(y => y.KorisnikID == KorisnikID).FirstOrDefault();

            if (korisnik.UlogaID == 2)
            {
                korisnik.UlogaID = 3;
                db.Update(korisnik);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Zarada()
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            var imePrezime = db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Ime).FirstOrDefault() + " " + db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Prezime).FirstOrDefault();
            var Username = db.Korisnici.Where(y => y.UlogaID == 1 && k.KorisnikID == y.KorisnikID).Select(y => y.UserName).FirstOrDefault();
            
            AdminVM n = new AdminVM { ImePrezime = imePrezime, UserName = Username };
            return View(n);

        }
        public IActionResult Stats()
        {

            MojDbContext db = new MojDbContext();

            var listaZanrova = db.Zanr.ToList();
            var listaRezervacija = db.Rezervacija.Where(y => y.Zakljucena == true).ToList();
            List<Rezervacija> novaLista = new List<Rezervacija>();

            foreach (var item in listaZanrova)
            {
                item.Zarada = 0;
                var filmovi = db.FilmZanr.Where(y => y.Zanr.Naziv == item.Naziv).Select(y => y.Film).ToList();

                foreach (var item1 in filmovi)
                {
                    foreach (var item2 in listaRezervacija)
                    {
                        string naziv = db.Projekcija.Where(y => y.Id == item2.ProjekcijaID).Select(y => y.Film.Naziv).FirstOrDefault();
                        if (naziv == item1.Naziv)
                        {
                            item.Zarada += item2.UkupnaCijena;
                            db.Update(item);
                            db.Update(item2);
                            db.SaveChanges();
                        }

                    }
                }
            }

            return new ViewAsPdf("ZaradaPoZanru", listaZanrova.OrderByDescending(y => y.Zarada).ToList());// { FileName = "Izvještaj zarade po žanru" };

        }
        public IActionResult Stats2()
        {
            MojDbContext db = new MojDbContext();
            var listaFilmova = db.Film.ToList();
            var listaRezervacija = db.Rezervacija.Where(y => y.Zakljucena == true).ToList();
            foreach(var item in listaFilmova)
            {
                item.Zarada = 0;
                foreach(var item2 in listaRezervacija)
                {
                    string naziv = db.Projekcija.Where(y => y.Id == item2.ProjekcijaID).Select(y => y.Film.Naziv).FirstOrDefault();
                    if (naziv == item.Naziv)
                    {
                        item.Zarada += item2.UkupnaCijena;
                        db.Update(item);
                        db.Update(item2);
                        db.SaveChanges();
                    }
                }
            }
            return new ViewAsPdf("ZaradaPoFilmu", listaFilmova.OrderByDescending(y => y.Zarada).ToList());// { FileName = "Izvještaj zarade po žanru" };

        }
        public IActionResult Pregled()
        {

            return RedirectToAction("Index","Film");
        }
        public IActionResult PrikazRezervacija()
        {
            return RedirectToAction("Index", "Rezervacija");
        }
        public IActionResult Ostalo()
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            var imePrezime = db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Ime).FirstOrDefault() + " " + db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Prezime).FirstOrDefault();
            var Username = db.Korisnici.Where(y => y.UlogaID == 1 && k.KorisnikID == y.KorisnikID).Select(y => y.UserName).FirstOrDefault();

            AdminVM n = new AdminVM { ImePrezime = imePrezime, UserName = Username };
            return View("ListaOstalog",n);
        }
      
    }

}