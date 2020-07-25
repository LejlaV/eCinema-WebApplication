using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Kino.Helper;

namespace Kino.Controllers
{
    [Autorizacija("Kupac")]
    public class KupacProfil : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public KupacProfil(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult MojProfil()
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            KupacIndex kupac = db.Korisnici.Where(i => i.KorisnikID == k.KorisnikID).Select(n => new KupacIndex
            {
                BrojTelefona = n.BrojTelefona,
                Datum = n.DatumRodjenja,
                Ime = n.Ime,
                Prezime = n.Prezime,
                KorisnikId = n.KorisnikID,
                KupacId = db.Kupac.Where(i => i.KorisnikID == n.KorisnikID).Select(b => b.KupacID).FirstOrDefault(),
                NazivGrada = n.Grad.Naziv,
                Slika=n.Slika
            }).FirstOrDefault();
            return View(kupac);
        }
       
        public IActionResult UrediProfil(int KupacId, string put)
        {
          
            MojDbContext db = new MojDbContext();
            Kupac k = db.Kupac.Find(KupacId);
          
            KupacUrediProfil model = db.Korisnici.Where(i => i.KorisnikID == k.KorisnikID).Select(b => new KupacUrediProfil
            {
                BrojTelefona = b.BrojTelefona,
                Email = b.Email,
                grad = db.Grad.Select(x => new SelectListItem(x.Naziv, x.GradID.ToString())).ToList(),
                GradId = b.GradID.Value,
                DatumRodjenja = b.DatumRodjenja,
                KorisnikId = b.KorisnikID,
                KupacId = k.KupacID,
                putanja = put
            }).FirstOrDefault();
            return View("UrediFormu", model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SnimiProfil(KupacUrediProfil o)
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
            if (o.KorisnikId!=0)
            {
                Korisnik k = db.Korisnici.Find(o.KorisnikId);
                if (k != null)
                {
                   k.GradID = o.GradId;
                   k.DatumRodjenja = o.DatumRodjenja;
                   k.BrojTelefona = o.BrojTelefona;
                   k.Email = o.Email;
                   k.Slika = uniqueFileName;
                   db.Korisnici.Update(k);
                   db.SaveChanges();
                }  
            }
            return RedirectToAction(nameof(MojProfil));
        }
        public IActionResult PromijeniLozinku()
        {
            MojDbContext db = new MojDbContext();

            Korisnik k = HttpContext.GetLogiraniKorisnik();
           
            LoginVM model = new LoginVM()
            {

                Username = k.UserName,
                Password = k.PasswordHash
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult PromijeniLozinkuSnimi(LoginVM model)
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            k.UserName= model.Username;
            k.PasswordHash = Criptography.Hash.Create(model.Password, k.PasswordSalt);
            db.Update(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction(nameof(MojProfil));
        }
    }
}