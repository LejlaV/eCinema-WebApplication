using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using PagedList;
using Microsoft.EntityFrameworkCore;
using Kino.Helper;

namespace Kino.Controllers
{
    public class ObjavaController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public ObjavaController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            MojDbContext db = new MojDbContext();
            List<Objava> o = db.Objava.Include(s => s.Korisnik).ToList();
            return View(o);
        }
        public IActionResult DodajForm()
        {        
            MojDbContext db = new MojDbContext();
            ObjavaAddVM model = new ObjavaAddVM();
            Korisnik uposlenik= HttpContext.GetLogiraniKorisnik();
            model.UposlenikID = uposlenik.KorisnikID;
           return View("DodajForm", model);
            
        }
        public IActionResult Snimi(ObjavaAddVM o)
        {
            MojDbContext db = new MojDbContext();
            string uniqueFileName = null;

                if (ModelState.IsValid)
                {
                    if (o.Slika != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + o.Slika.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        o.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                } 
                Objava ob = new Objava
            {
                Naslov = o.Naslov,
                Sadrzaj = o.Sadrzaj,
                DatumObjave = DateTime.Now,
                KorisnikID = o.UposlenikID,
                Slika = uniqueFileName
            };  
            db.Add(ob);
            db.SaveChanges();
            return Redirect("/Objava?poruka=Uspjesno ste dodali objavu!");
            //}
        }
        IActionResult SnimiFormu(ObjavaAddVM o)
        {
            MojDbContext db = new MojDbContext();
            string uniqueFileName = null;

            if (ModelState.IsValid)
            {
                if (o.Slika != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + o.Slika.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    o.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            }
            if (db.Objava.Find(o.ObjavaID) != null)
            {
                db.Objava.Find(o.ObjavaID).ObjavaID = o.ObjavaID;
                db.Objava.Find(o.ObjavaID).Naslov = o.Naslov;
                db.Objava.Find(o.ObjavaID).Sadrzaj = o.Sadrzaj;
                db.Objava.Find(o.ObjavaID).DatumObjave = DateTime.Now;
                db.Objava.Find(o.ObjavaID).KorisnikID = o.UposlenikID;
                if (uniqueFileName != null)
                db.Objava.Find(o.ObjavaID).Slika = uniqueFileName;
                db.Update(o);
                db.SaveChanges();
                return Redirect("/Objava?poruka=Uspjesno ste editovali polja za objavu!");
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Uredi(int ObjavaID, string put)
        {
            if (ObjavaID == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            MojDbContext db = new MojDbContext();
            Objava o = db.Objava.Find(ObjavaID);
            if (o == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ObjavaAddVM model = new ObjavaAddVM
            {
                ObjavaID = o.ObjavaID,
                Naslov = o.Naslov,
                Sadrzaj = o.Sadrzaj,
                DatumObjave = o.DatumObjave,
                UposlenikID = o.KorisnikID,
                putanjaSlike = put
            };

            return View("UrediFormu", model);
        }
        public IActionResult Obrisi(int ObjavaId)
        {
            MojDbContext db = new MojDbContext();
            Objava o = db.Objava.Where(s => s.ObjavaID == ObjavaId).FirstOrDefault();
            if (o== null)
            {
                return Content("Objava ne postoji");
            }
            List<Komentar> k = db.Komentar.Where(b => b.ObjavaId == ObjavaId).ToList();
            foreach(var b in k)
            {
                db.Remove(b);
            }
            db.Remove(o);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(Index));

        }
    }
}