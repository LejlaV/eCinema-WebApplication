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
using PagedList;

namespace Kino.Controllers
{
    public class ZaposlenikController : Controller
    {
        public IActionResult MojProfil()
        {
            MojDbContext db = new MojDbContext();

            Korisnik korisnik = HttpContext.GetLogiraniKorisnik();

            ZaposlenikProfilVM mojProfil = db.Korisnici.Where(x => x.KorisnikID == korisnik.KorisnikID).Select(x => new ZaposlenikProfilVM()
            {
                ImePrezime=x.Ime+" "+x.Prezime,
                KorisnickaUloga=x.Uloga.Naziv,
                KorisnickoIme=x.UserName,
                DatumRodjenja=x.DatumRodjenja,
                Email=x.Email,
                BrojTelefona=x.BrojTelefona,
                Grad=x.Grad.Naziv,
                putanjaSlike=x.Slika
            }).FirstOrDefault();

            return View(mojProfil);
        }
        public IActionResult Lokacije()
        {
            return View();
        }

        public IActionResult FilmoviProjekcije()
        {
            return View();
        }

        public IActionResult ObjaveNagradneIgre()
        {
            return View();
        }
        public IActionResult KinoObjekatIndex(string poruka)
        {
            MojDbContext db = new MojDbContext();
            List<KinoObjekat> kina = db.KinoObjekat.Include(x => x.Adresa).ToList();
            ViewData["kina"] = poruka;

            return View(kina);
        }
        public IActionResult DvoranaIndex(string dv)
        {
            MojDbContext db = new MojDbContext();
            List<Dvorana> dvorane = db.Dvorana.Include(x => x.VrstaDvorane)
                                              .Include(x => x.KinoObjekat).ToList();
            ViewData["dvorane"] = dv;
            return View(dvorane);
        }
        public IActionResult PrikazRezervacija()
        {
            return RedirectToAction("Index", "Rezervacija");
        }
        public IActionResult OcjenjeniFilmovi()
        {
            MojDbContext db = new MojDbContext();
            var listaFilmova = db.Film.ToList();
            var listaOcjena = db.FilmOcjena.ToList();
            float? prOcjena = 0;
            foreach (var item in listaFilmova)
            {
                foreach (var item2 in listaOcjena)
                {
                    item2.prosjecnaOcjena = 0;

                         prOcjena = db.FilmOcjena.Where(x => x.FilmID == item2.FilmID).Average(x => x.Ocjena);

                    item2.prosjecnaOcjena = prOcjena;
                    db.FilmOcjena.Update(item2);
                    db.SaveChanges();
                }
            }
            return new ViewAsPdf("OcjenjeniFilmovi", listaOcjena.OrderByDescending(y => y.prosjecnaOcjena).ToList());
        }
       
        public ActionResult PosaljiPoruku()
        {
            return View();
        }
    }
}