using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kino.Helper;
using Kino.Models;
using Kino.Models.ManyToManyClasses;
using Kino.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kino.Controllers
{
    
    public class FilmController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public MojDbContext db = new MojDbContext();
        public FilmController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            MojDbContext db = new MojDbContext();
            var lista = db.Film.Select(y => new FilmIndexVM { Id = y.Id, 
                Naziv = y.Naziv, 
                Sinopsis = y.Sinopsis,
                Trajanje = y.Trajanje,
                Dobno = y.DobnoOgraničenje,
                Godina = y.GodinaIzdavanja,
                Aktivan = y.Aktuelan, 
                putanjaSlike = y.Slika,
                Trailer = y.Trailer,
                //Ocjena = db.FilmOcjena.FirstOrDefault(x => x.KupacID == HttpContext.GetLogiraniKorisnik().KorisnikID && x.FilmID == y.Id).Ocjena,
                //ProsjecnaOcjena = db.FilmOcjena.Where(x => x.FilmID == y.Id).Average(x => x.Ocjena)
            })
                .ToList().OrderBy(y => y.Godina).ToList();
            foreach (var item in lista)
            {
                item.Zanrovi = new List<string>();
                item.Zanrovi.AddRange(db.FilmZanr.Where(y => y.FilmId == item.Id).Select(y => y.Zanr.Naziv).ToList());
                item.Glumci = new List<string>();
                item.Glumci.AddRange(db.FilmGlumac.Where(y => y.FilmId == item.Id).Select(y => y.Glumac.Ime + " " + y.Glumac.Prezime).ToList());
                item.Reziseri = new List<string>();
                item.Reziseri.AddRange(db.FilmReziser.Where(y => y.FilmId == item.Id).Select(y => y.Reziser.Ime + " " + y.Reziser.Prezime).ToList());
               
            }
          
            Korisnik k = HttpContext.GetLogiraniKorisnik();

            if (k.Uloga.Naziv.Contains("Administrator"))
            {
                return View("PregledFilmova", lista);
            }

            if (k.Uloga.Naziv.Contains("Uposlenik"))
            {
                return View("PregledFilmova", lista);
            }
            return View(lista);
        }
        //public void dodajOcjenu(int filmID, string ocjena)
        //{
        //    float ocj = 0;
        //    switch (ocjena)
        //    {
        //        case "5":
        //            ocj = 5;
        //            break;
        //        case "4 and a half":
        //            ocj = 4.5F;
        //            break;
        //        case "4":
        //            ocj = 4;
        //            break;
        //        case "3 and a half":
        //            ocj = 3.5F;
        //            break;
        //        case "3":
        //            ocj = 3;
        //            break;
        //        case "2 and a half":
        //            ocj = 2.5F;
        //            break;
        //        case "2":
        //            ocj = 2;
        //            break;
        //        case "1 and a half":
        //            ocj = 1.5F;
        //            break;
        //        case "1":
        //            ocj = 1;
        //            break;
        //        case "half":
        //            ocj = 0.5F;
        //            break;

        //        default:
        //            break;

        //    }
        //    MojDbContext db = new MojDbContext();
        //    FilmOcjena filmOcj = db.FilmOcjena.FirstOrDefault(x => x.FilmID == filmID && x.KupacID == HttpContext.GetLogiraniKorisnik().KorisnikID);
        //    if (filmOcj == null)
        //    {
        //        db.FilmOcjena.Add(new FilmOcjena()
        //        {
        //            FilmID = filmID,
        //            KupacID = HttpContext.GetLogiraniKorisnik().KorisnikID,
        //            Ocjena = ocj
        //        }
        //        );
        //    }
        //    else
        //    {
        //        filmOcj.Ocjena = ocj;
        //        db.FilmOcjena.Update(filmOcj);
        //    }
        //    db.SaveChanges();
        //}
        public IActionResult Dodaj(int id, string put)
        {
            MojDbContext db = new MojDbContext();
            FilmAddVM model = new FilmAddVM();

            if (id != 0)
            {
                Film noob = db.Film.Find(id);
                model.Id = noob.Id;
                model.Naziv = noob.Naziv;
                model.Sinopsis = noob.Sinopsis;
                model.Aktuelan = noob.Aktuelan;
                model.GodinaIzdavanja = noob.GodinaIzdavanja;
                model.Trajanje = noob.Trajanje;
                model.DobnoOgraničenje = noob.DobnoOgraničenje;
                model.Zanr = db.Zanr.Select(y => new SelectListItem { Value = y.ZanrID.ToString(), Text = y.Naziv }).ToList();
                model.Reziser = db.Reziser.Select(y => new SelectListItem { Value = y.ReziserID.ToString(), Text = y.Ime + " " + y.Prezime }).ToList();
                model.Glumac = db.Glumac.Select(y => new SelectListItem { Value = y.GlumacID.ToString(), Text = y.Ime + " " + y.Prezime }).ToList();
                model.putanjaSlike = put;
                model.Trailer = noob.Trailer;
            }
            else
            {

                model.Zanr = db.Zanr.Select(y => new SelectListItem { Value = y.ZanrID.ToString(), Text = y.Naziv }).ToList();
                model.Reziser = db.Reziser.Select(y => new SelectListItem { Value = y.ReziserID.ToString(), Text = y.Ime + " " + y.Prezime }).ToList();
                model.Glumac = db.Glumac.Select(y => new SelectListItem { Value = y.GlumacID.ToString(), Text = y.Ime + " " + y.Prezime }).ToList();
            }
            return View(model);

        }
        public IActionResult DodajSnimi(FilmAddVM n)
        {
            string uniqueFileName = null;
            if (ModelState.IsValid)
            {
                if (n.Slika != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + n.Slika.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    n.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            }
            if (n.Id == 0)
            {
                if (Postoji(n))
                    return Redirect("/Film?poruka1=Film vec postoji u bazi!");
                Film novi = new Film();
                novi.Naziv = n.Naziv;
                novi.Sinopsis = n.Sinopsis;
                novi.Trajanje = n.Trajanje;
                novi.GodinaIzdavanja = n.GodinaIzdavanja;
                novi.Aktuelan = n.Aktuelan;
                novi.DobnoOgraničenje = n.DobnoOgraničenje;
                if (n.Trailer!=null)
                {
                    novi.Trailer = ProvjeriTrailer(n.Trailer);

                }
                else
                {
                    novi.Trailer = n.Trailer;
                }
                
                if (uniqueFileName != null)
                    novi.Slika = uniqueFileName;
                db.Add(novi);
                db.SaveChanges();
                var FilmID = db.Film.Where(y => y.Naziv == n.Naziv).FirstOrDefault().Id;
                foreach (var item in n.Zanrovi)
                {
                    FilmZanr filmgenre = new FilmZanr();
                    filmgenre.FilmId = FilmID;
                    filmgenre.ZanrId = item;
                    db.Add(filmgenre);
                    db.SaveChanges();
                }
                foreach (var item in n.Reziseri)
                {
                    FilmReziser filmreziser = new FilmReziser();
                    filmreziser.FilmId = FilmID;
                    filmreziser.ReziserID = item;
                    db.Add(filmreziser);
                    db.SaveChanges();
                }
                foreach (var item in n.Glumci)
                {
                    FilmGlumac filmmovie = new FilmGlumac();
                    filmmovie.FilmId = FilmID;
                    filmmovie.GlumacID = item;
                    db.Add(filmmovie);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {

                if (db.Film.Find(n.Id) != null)
                {
                    db.Film.Find(n.Id).Id = n.Id;
                    db.Film.Find(n.Id).Naziv = n.Naziv;
                    db.Film.Find(n.Id).Sinopsis = n.Sinopsis;
                    db.Film.Find(n.Id).Trajanje = n.Trajanje;
                    db.Film.Find(n.Id).GodinaIzdavanja = n.GodinaIzdavanja;
                    db.Film.Find(n.Id).Aktuelan = n.Aktuelan;
                    db.Film.Find(n.Id).DobnoOgraničenje = n.DobnoOgraničenje;
                    if (n.Trailer != null)
                        db.Film.Find(n.Id).Trailer = ProvjeriTrailer(n.Trailer);
                    else
                        db.Film.Find(n.Id).Trailer = n.Trailer;
                    var t = db.FilmZanr.Where(y => y.FilmId == n.Id).ToList();
                    if (t.Count() == n.Zanrovi.Count())
                    {
                        int brojac = 0;
                        foreach (var item in t)
                        {
                            item.FilmId = n.Id;
                            item.ZanrId = n.Zanrovi[brojac++];
                        }
                        db.SaveChanges();

                    }
                    else
                    {
                        db.RemoveRange(db.FilmZanr.Where(y => y.FilmId == n.Id));
                        db.SaveChanges();
                        foreach (var item in n.Zanrovi)
                        {
                            FilmZanr filmgenre = new FilmZanr();
                            filmgenre.FilmId = n.Id;
                            filmgenre.ZanrId = item;
                            db.Add(filmgenre);
                            db.SaveChanges();
                        }
                    }
                    var ta = db.FilmReziser.Where(y => y.FilmId == n.Id).ToList();
                    if (ta.Count() == n.Reziseri.Count())
                    {
                        int brojac = 0;
                        foreach (var item in ta)
                        {
                            item.FilmId = n.Id;
                            item.ReziserID = n.Reziseri[brojac++];
                        }
                        db.SaveChanges();

                    }
                    else
                    {
                        db.RemoveRange(db.FilmReziser.Where(y => y.FilmId == n.Id));
                        db.SaveChanges();
                        foreach (var item in n.Reziseri)
                        {
                            FilmReziser filmreziser = new FilmReziser();
                            filmreziser.FilmId = n.Id;
                            filmreziser.ReziserID = item;
                            db.Add(filmreziser);
                            db.SaveChanges();
                        }
                    }
                    var taf = db.FilmGlumac.Where(y => y.FilmId == n.Id).ToList();
                    if (taf.Count() == n.Glumci.Count())
                    {
                        int brojac = 0;
                        foreach (var item in taf)
                        {
                            item.FilmId = n.Id;
                            item.GlumacID = n.Glumci[brojac++];
                        }
                        db.SaveChanges();

                    }
                    else
                    {
                        db.RemoveRange(db.FilmGlumac.Where(y => y.FilmId == n.Id));
                        db.SaveChanges();
                        foreach (var item in n.Glumci)
                        {
                            FilmGlumac filmglumac = new FilmGlumac();
                            filmglumac.FilmId = n.Id;
                            filmglumac.GlumacID = item;
                            db.Add(filmglumac);
                            db.SaveChanges();
                        }
                    }
                    if (uniqueFileName != null)
                        db.Film.Find(n.Id).Slika = uniqueFileName;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");

            }

        }
        public IActionResult Obrisi(int id)
        {
            db.RemoveRange(db.FilmZanr.Where(y => y.FilmId == id).ToList());
            db.RemoveRange(db.FilmReziser.Where(y => y.FilmId == id).ToList());
            db.RemoveRange(db.FilmGlumac.Where(y => y.FilmId == id).ToList());
            db.Remove(db.Film.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        bool Postoji(FilmAddVM n)
        {
            List<Film> filmovi = db.Film.ToList();
            foreach (var item in filmovi)
            {
                if (string.Compare(n.Naziv, item.Naziv) == 0 && n.GodinaIzdavanja == item.GodinaIzdavanja)
                    return true;
            }
            return false;
        }
        string ProvjeriTrailer(string trailer)
        {
            if (trailer.Contains("watch?v="))
            {
                trailer=trailer.Replace("watch?v=", "embed/");
            }
            return trailer;
        }
    }
}