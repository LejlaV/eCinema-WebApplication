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
using Microsoft.AspNetCore.Http;

namespace Kino.Controllers
{
    public class GlumacController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public GlumacController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(string poruka, string poruka1,int ? page)
        {
            MojDbContext db = new MojDbContext();

            var k2 = db.Glumac.Select(y => new GlumacAddVM
            {
                GlumacID=y.GlumacID,
                Ime = y.Ime,
                Prezime = y.Prezime,
                DatumRodjenja = y.DatumRodjenja,
                MjestoRodjenja = y.Grad.Naziv,
                putanjaSlike=y.CV

            })
            .ToList().ToPagedList(page??1,3);

            ViewData["poruka-kljuc"] = poruka;
            ViewData["poruka1-kljuc"] = poruka1;
            

            return View(k2);
        }
        public IActionResult Dodaj(int id,string put)
        {
            MojDbContext db = new MojDbContext();
            if (id != 0)
            {
                GlumacAddVM v = new GlumacAddVM
                {
                    GlumacID = db.Glumac.Find(id).GlumacID,
                    Ime = db.Glumac.Find(id).Ime,
                    Prezime = db.Glumac.Find(id).Prezime,
                    DatumRodjenja = db.Glumac.Find(id).DatumRodjenja,
                    putanjaSlike = put,
                    GradID = db.Glumac.Find(id).GradID,
                };
                
                v.Grad = db.Grad.Select(o => new SelectListItem(o.Naziv, o.GradID.ToString())).ToList();

                return View("DodajForm", v);
            }
            else
            {
                GlumacAddVM glumac = new GlumacAddVM();
                glumac.Grad = db.Grad.Select(o => new SelectListItem(o.Naziv, o.GradID.ToString())).ToList();

                return View("DodajForm", glumac);
            }
        }

        public IActionResult DodajSnimi(GlumacAddVM glumac)
        {
            string uniqueFileName = null;

            if (ModelState.IsValid)
            {
                if (glumac.Slika != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + glumac.Slika.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    glumac.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            }
            MojDbContext db = new MojDbContext();
            if (db.Glumac.Find(glumac.GlumacID) != null)
            {
                db.Glumac.Find(glumac.GlumacID).GlumacID = glumac.GlumacID;
                db.Glumac.Find(glumac.GlumacID).Ime = glumac.Ime;
                db.Glumac.Find(glumac.GlumacID).Prezime = glumac.Prezime;
                db.Glumac.Find(glumac.GlumacID).DatumRodjenja = glumac.DatumRodjenja;
                db.Glumac.Find(glumac.GlumacID).GradID = glumac.GradID;
                if(uniqueFileName!=null)
                    db.Glumac.Find(glumac.GlumacID).CV = uniqueFileName;
                db.SaveChanges();
                return Redirect("/Glumac?poruka=Uspjesno ste editovali polja za glumca!");
            }
            else
            {

                if (Postoji(glumac.Ime, glumac.Prezime))
                    return Redirect("/Glumac?poruka1=Glumac vec postoji u bazi!");

                if (ModelState.IsValid)
                {
                    if (glumac.Slika != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + glumac.Slika.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        glumac.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
                Glumac noviGlumac = new Glumac
                {
                    Ime = glumac.Ime,
                    Prezime = glumac.Prezime,
                    DatumRodjenja = glumac.DatumRodjenja,
                    GradID = glumac.GradID,
                    CV = uniqueFileName
                };
                db.Add(noviGlumac);
                db.SaveChanges();
                return Redirect("/Glumac?poruka=Uspjesno ste dodali glumca!");
            }
           }
            public IActionResult Obrisi(string ime, string prezime)
            {
                MojDbContext db = new MojDbContext();
                Glumac g = db.Glumac.Where(y => y.Ime.Equals(ime) == true && y.Prezime.Equals(prezime) == true).ToList().FirstOrDefault();
                if (g != null)
                {
                    db.Glumac.Remove(g);
                    db.SaveChanges();
                    return Redirect("/Glumac?poruka=Uspjesno ste obrisali glumca!");
                }
                else
                {
                    return Redirect("/Glumac?poruka1 = Ne postoji trazeni glumac!");
                }


            }
            public bool Postoji(string ime, string prezime)
            {
                MojDbContext db = new MojDbContext();
                List<Glumac> glumci = db.Glumac.ToList();
                foreach (var item in glumci)
                {
                    if (string.Compare(ime, item.Ime) == 0 && string.Compare(prezime, item.Prezime) == 0)
                        return true;
                }
                return false;
            }
        }

    }
