using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using PagedList;
namespace Kino.Controllers
{
    public class ReziserController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public ReziserController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(string poruka, string poruka1,int?page)
        {
            MojDbContext db = new MojDbContext();


            var k2 = db.Reziser.Select(y => new ReziserAddVM
            {
                ReziserID=y.ReziserID,
                Ime = y.Ime,
                Prezime = y.Prezime,
                DatumRodjenja = y.DatumRodjenja,
                MjestoRodjenja = y.Grad.Naziv,
                putanjaSlike=y.CV

            })
            .ToList().ToPagedList(page??1,3);
            ViewData["poruka-kljuc"] = poruka;
            ViewData["poruka1-kljuc"] = poruka1;

            return View(nameof(Index),k2);
        }
        public IActionResult Dodaj(int id, string put)
        {
            MojDbContext db = new MojDbContext();
            if (id != 0)
            {
                ReziserAddVM v = new ReziserAddVM
                {
                    ReziserID = db.Reziser.Find(id).ReziserID,
                    Ime = db.Reziser.Find(id).Ime,
                    Prezime = db.Reziser.Find(id).Prezime,
                    DatumRodjenja = db.Reziser.Find(id).DatumRodjenja,
                    putanjaSlike = db.Reziser.Find(id).CV,
                    GradID = db.Reziser.Find(id).GradID,
                };

                v.Grad = db.Grad.Select(o => new SelectListItem(o.Naziv, o.GradID.ToString())).ToList();

                return View("DodajForm", v);
            }
            else
            {
                ReziserAddVM reziser = new ReziserAddVM();
                reziser.Grad = db.Grad.Select(o => new SelectListItem(o.Naziv, o.GradID.ToString())).ToList();

                return View("DodajForm", reziser);
            }
            
        }
        public bool Postoji(string ime, string prezime)
        {
            MojDbContext db = new MojDbContext();
            List<Reziser> reziseri = db.Reziser.ToList();
            foreach (var item in reziseri)
            {
                if (string.Compare(ime, item.Ime) == 0 && string.Compare(prezime, item.Prezime) == 0)
                    return true;
            }
            return false;
        }
        public IActionResult DodajSnimi(ReziserAddVM reziser)
        {
            MojDbContext db = new MojDbContext();
            string uniqueFileName = null;
            if (ModelState.IsValid)
            {
                if (reziser.Slika != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + reziser.Slika.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    reziser.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            }
            if (reziser.ReziserID!= 0)
            {
                db.Reziser.Find(reziser.ReziserID).ReziserID = reziser.ReziserID;
                db.Reziser.Find(reziser.ReziserID).Ime = reziser.Ime;
                db.Reziser.Find(reziser.ReziserID).Prezime = reziser.Prezime;
                db.Reziser.Find(reziser.ReziserID).DatumRodjenja = reziser.DatumRodjenja;
                db.Reziser.Find(reziser.ReziserID).GradID = reziser.GradID;
                if (uniqueFileName != null)
                    db.Reziser.Find(reziser.ReziserID).CV = uniqueFileName;
                db.SaveChanges();
                return Redirect("/Reziser?poruka=Uspjesno ste editovali polja za rezisera!");
            }
            else {
                if (Postoji(reziser.Ime, reziser.Prezime))
                    return Redirect("/Reziser?poruka1=Reziser vec postoji u bazi!");

                if (ModelState.IsValid)
                {
                    if (reziser.Slika != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + reziser.Slika.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        reziser.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
                Reziser noviReziser = new Reziser
                {
                    Ime = reziser.Ime,
                    Prezime = reziser.Prezime,
                    DatumRodjenja = reziser.DatumRodjenja,
                    GradID = reziser.GradID,
                    CV = uniqueFileName
                };
                db.Add(noviReziser);
                db.SaveChanges();
                return Redirect("/Reziser?poruka=Uspjesno ste dodali rezisera!");
            }
        }
        public IActionResult Obrisi(string ime, string prezime)
        {
            MojDbContext db = new MojDbContext();
            Reziser g = db.Reziser.Where(y => y.Ime.Equals(ime) == true && y.Prezime.Equals(prezime) == true).ToList().FirstOrDefault();
            if (g != null)
            {
                db.Reziser.Remove(g);
                db.SaveChanges();
                return Redirect("/Reziser?poruka=Uspjesno ste obrisali rezisera!");
            }
            else
            {
                return Redirect("/Reziser?poruka1 = Ne postoji trazeni reziser!");
            }


        }
    }
}