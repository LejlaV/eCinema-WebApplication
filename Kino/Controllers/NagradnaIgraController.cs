using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Helper;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kino.Controllers
{


    public class NagradnaIgraController : Controller
    {
        public IActionResult Index()//uraditi view
        {
            MojDbContext db = new MojDbContext();

            List<NagradnaIgra> igra = db.NagradnaIgra.ToList();
            db.Dispose();
            return View(igra);
        }
        public IActionResult Dodaj()//uraditi view
        {
            MojDbContext db = new MojDbContext();

            NagradnaIgraDodajVM model = new NagradnaIgraDodajVM()
            {
                NagradnaIgra = new NagradnaIgra()
            };
            return View(model);
        }
        public IActionResult Snimi(NagradnaIgraDodajVM model)
        {
            Korisnik uposlenik = HttpContext.GetLogiraniKorisnik();
            MojDbContext db = new MojDbContext();
            NagradnaIgra n = new NagradnaIgra
            {
                Naziv = model.NagradnaIgra.Naziv,
                Opis = model.NagradnaIgra.Opis,
                Pocetak = model.NagradnaIgra.Pocetak,
                Kraj = model.NagradnaIgra.Kraj,
                KorisnikID = uposlenik.KorisnikID
            };
            db.NagradnaIgra.Add(n);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int id)
        {
            MojDbContext db = new MojDbContext();
            NagradnaIgra nova = db.NagradnaIgra.Find(id);
            List<NagradnaIgraKupac> kupci = db.NagradnaIgraKupac.Where(i => i.NagradnaIgraId == id).ToList();
            foreach (var b in kupci)
            {
                db.NagradnaIgraKupac.Remove(b);
            }
            db.NagradnaIgra.Remove(nova);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Index");
        }
        public IActionResult Uredi(int id)
        {
            MojDbContext db = new MojDbContext();
            NagradnaIgra a = db.NagradnaIgra.Where(i => i.NagradnaIgraID == id).FirstOrDefault();
            NagradnaIgraUrediVM model = new NagradnaIgraUrediVM
            {
                Id = a.NagradnaIgraID,
                Naziv = a.Naziv,
                Pocetak = a.Pocetak,
                Kraj = a.Kraj,
                Opis = a.Opis
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(NagradnaIgraUrediVM model)
        {
            MojDbContext db = new MojDbContext();
            NagradnaIgra igra = db.NagradnaIgra.Where(u => u.NagradnaIgraID == model.Id).FirstOrDefault();
            igra.NagradnaIgraID = model.Id;
            igra.Naziv = model.Naziv;
            igra.Opis = model.Opis;
            igra.Pocetak = model.Pocetak;
            igra.Kraj = model.Kraj;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DodijeliNagradu(int id)
        {
            MojDbContext db = new MojDbContext();
            NagradnaIgra n = db.NagradnaIgra.Where(u => u.NagradnaIgraID == id).FirstOrDefault();
            Random random = new Random();
            var kupci = db.Kupac.ToList();
            int broj = kupci.Count();
            int[] Kupci = new int[broj];
            for (int i = 0; i < broj; i++)
            {
                Kupci[i] = kupci[i].KupacID;
            }
            int k = random.Next(0, broj);

            KupacNagradnaIgraDodajVM model = new KupacNagradnaIgraDodajVM()
            {
                KupacNagradnaIgra = new NagradnaIgraKupac(),
                KupacId = Kupci[k],
                NagradnaIgraId = n.NagradnaIgraID,
                Kupac = db.Kupac.Select(y => new SelectListItem
                {
                    Value = y.KupacID.ToString(),
                    Text = y.Korisnik.Ime + " " + y.Korisnik.Prezime
                }).ToList(),
                Nagradnaigra = db.NagradnaIgra.Select(x => new SelectListItem
                {
                    Value = x.NagradnaIgraID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult SnimiNagradnuIgru(KupacNagradnaIgraDodajVM model)
        {
            MojDbContext db = new MojDbContext();
            NagradnaIgraKupac kupac = model.KupacNagradnaIgra;
            kupac.KupacId = model.KupacId;
            List<SelectListItem> k = db.Kupac.Select(b => new SelectListItem
            {
                Value = b.KupacID.ToString(),
                Text = b.Korisnik.Ime + " "+b.Korisnik.Prezime
            }).ToList();
            k = model.Kupac;
            kupac.NagradnaIgraId = model.NagradnaIgraId;
            List<SelectListItem> i = db.NagradnaIgra.Select(v => new SelectListItem
            {
                Value = v.NagradnaIgraID.ToString(),
                Text = v.Naziv
            }).ToList();
            i = model.Nagradnaigra;
          
            db.NagradnaIgraKupac.Add(kupac);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult PrikazKupacaNagradneIgre()
        {
            MojDbContext db = new MojDbContext();
            NagradnaIgraKupciPrikazVM model = new NagradnaIgraKupciPrikazVM
            {
                lista = db.NagradnaIgraKupac.Select(y => new NagradnaIgraKupciPrikazVM.Row()
                {
                    Id = y.NagradnaIgraKupacId,
                    KupacId = y.KupacId,
                    NagradnaIgraId = y.NagradnaIgraId,
                    Kupac = y.Kupac.Korisnik.Ime + " " + y.Kupac.Korisnik.Prezime,
                    Nagrada = y.NagradnaIgra.Naziv

                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
    }
}

