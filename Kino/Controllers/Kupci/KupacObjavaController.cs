using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Helper;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Kino.Controllers.Kupci
{

    [Autorizacija("Kupac")]
    public class KupacObjavaController : Controller
    {
        public IActionResult Index(int? page)
        {
            MojDbContext db = new MojDbContext();
            var o = db.Objava.Include(s => s.Korisnik).ToList().ToPagedList(page ?? 1, 3);
            return View(o);
        }
        public IActionResult PrikaziVise(int ObjavaID)
        {
            MojDbContext db = new MojDbContext();
            Korisnik c = HttpContext.GetLogiraniKorisnik();
            ObjavaIndex model = db.Objava.Where(n => n.ObjavaID == ObjavaID).Select(h => new ObjavaIndex
            {
                DatumObjave = h.DatumObjave,
                KorisnikID = h.KorisnikID,
                Naslov = h.Naslov,
                ObjavaID = h.ObjavaID,
                ImePrez=c.Ime+" "+c.Prezime,
                komentari=db.Komentar.Where(b=>b.ObjavaId==h.ObjavaID).ToList(),
                Sadrzaj = h.Sadrzaj,
                Slika = h.Slika
            }).FirstOrDefault();
            return View(model);
        }
        public IActionResult Obrisi(int id)
        { 
            MojDbContext db = new MojDbContext();
            Komentar k = db.Komentar.Find(id);
            int a = k.ObjavaId;
            if (id == 0)
            {
                return View(nameof(Index));
            }

            if (k != null)
            {
                db.Komentar.Remove(k);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("PrikaziVise",new { ObjavaID =a});
            }
            return View(nameof(Index));
        }
    }
}