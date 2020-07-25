using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kino.Models;
using Kino.ViewModels;
using Kino.Helper;

namespace Kino.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k.Uloga.Naziv.Contains("Kupac")) {
                var mod = db.Film.Where(n => n.Aktuelan == true).Select(b => new FilmKupacVM
                {
                    Id = b.Id,
                    Sinopsis = b.Sinopsis,
                    Naziv = b.Naziv,
                    PutanjaSlike = b.Slika

                }).ToList();
                foreach (var item in mod)
                {
                    item.Zanrovi = new List<string>();
                    item.Zanrovi.AddRange(db.FilmZanr.Where(y => y.FilmId == item.Id).Select(y => y.Zanr.Naziv).ToList());
                }
                return View(mod);
            }
            else if (k.Uloga.Naziv.Contains("Administrator"))
            {
                var imePrezime = db.Korisnici.Where(y => y.UlogaID == 1).Select(y => y.Ime).FirstOrDefault()+" "+db.Korisnici.Where(y=>y.UlogaID==1).Select(y=>y.Prezime).FirstOrDefault();
                var trenutnoKorisnika = db.Korisnici.Count();
                var zarada = db.Rezervacija.Sum(y => y.UkupnaCijena);
                var Username = db.Korisnici.Where(y => y.UlogaID == 1 && k.KorisnikID == y.KorisnikID).Select(y => y.UserName).FirstOrDefault();
                var Lokacija = db.Adresa.Count();
                var trenutnoFilmova = db.Film.Count();
                var trenutnoRezervacija = db.Rezervacija.Count();
                AdminVM n = new AdminVM { ImePrezime = imePrezime, UkupanBrojKorisnika = trenutnoKorisnika, UkupnaZarada = zarada,UserName=Username,TrenutnoLokacija=Lokacija,TrenutnoFilmova=trenutnoFilmova, TrenutnoRezervacija=trenutnoRezervacija};
                return View("Admin",n);
            }
            else if (k.Uloga.Naziv.Contains("Uposlenik"))
            {
                    var lista = db.Film.Select(y => new ZaposlenikFilmIndexVM
                    {
                        Id = y.Id,
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

                    return View("Zaposlenik", lista);
                
            }
            else
            {
                return View();
            }
        }
        public IActionResult PrikaziVise(int id)
        {
            MojDbContext db = new MojDbContext();
            var lista = db.Film.Where(n => n.Id == id).Select(b => new FilmKupacVM
            {
                Id = b.Id,
                Sinopsis = b.Sinopsis,
                Naziv = b.Naziv,
                PutanjaSlike = b.Slika,
                Godina = b.GodinaIzdavanja,
                Dobno = b.DobnoOgraničenje,
                Trajanje = b.Trajanje,
                Trailer = b.Trailer,
                Zanrovi=db.FilmZanr.Where(y=>y.FilmId==id).Select(n=>n.Zanr.Naziv).ToList(),
                Glumci=db.FilmGlumac.Where(c=>c.FilmId==id).Select(y => y.Glumac.Ime + " " + y.Glumac.Prezime).ToList(),
                Reziseri=db.FilmReziser.Where(c => c.FilmId == id).Select(y => y.Reziser.Ime + " " + y.Reziser.Prezime).ToList(),
                ProsjecnaOcjena = db.FilmOcjena.Where(x => x.FilmID == id).Average(x => x.Ocjena),
                projekcije = db.Projekcija.Where(b => b.FilmID == id).Select(n => new FilmKupacVM.Projekcija
                    {
                   ProjekcijaId=n.Id,
                   DatumPočetka=n.Pocetak,
                   Dvorana=n.Dvorana.Naziv,
                   Cijena=n.Cijena
                }).ToList()
            }).ToList();

            return View(lista);
        }
        [Autorizacija("Kupac")]
        public IActionResult Pretraga(int id)
        {
            MojDbContext db = new MojDbContext();
      
            var mod = db.FilmZanr.Where(n =>n.ZanrId == id && n.Film.Aktuelan==true).Select(b => new FilmKupacVM
            {
                Id = b.Film.Id,
                Sinopsis = b.Film.Sinopsis,
                Naziv = b.Film.Naziv,
                PutanjaSlike = b.Film.Slika
            }).ToList();
            foreach (var item in mod)
            {
                item.Zanrovi = new List<string>();
                item.Zanrovi.AddRange(db.FilmZanr.Where(y => y.FilmId == item.Id).Select(y => y.Zanr.Naziv).ToList());

            }
            return View("Index",mod);

        }

        public IActionResult dodajOcjenu(int filmID, string ocjena)
        {
            float ocj = 0;
            switch (ocjena)
            {
                case "5":
                    ocj = 5;
                    break;
                case "4 and a half":
                    ocj = 4.5F;
                    break;
                case "4":
                    ocj = 4;
                    break;
                case "3 and a half":
                    ocj = 3.5F;
                    break;
                case "3":
                    ocj = 3;
                    break;
                case "2 and a half":
                    ocj = 2.5F;
                    break;
                case "2":
                    ocj = 2;
                    break;
                case "1 and a half":
                    ocj = 1.5F;
                    break;
                case "1":
                    ocj = 1;
                    break;
                case "half":
                    ocj = 0.5F;
                    break;

                default:
                    break;

            }
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            int KupacId = db.Kupac.Where(b => b.KorisnikID == k.KorisnikID).Select(b => b.KupacID).FirstOrDefault(); 
            FilmOcjena filmOcj = db.FilmOcjena.FirstOrDefault(x => x.FilmID == filmID && x.KupacID ==KupacId);
            if (filmOcj == null)
            {
                db.FilmOcjena.Add(new FilmOcjena()
                {
                    FilmID = filmID,
                    KupacID = KupacId,
                    Ocjena = ocj
                }
                );
            }
            else
            {
                filmOcj.Ocjena = ocj;
                db.FilmOcjena.Update(filmOcj);
            }
            db.SaveChanges();

   
        return RedirectToAction("PrikaziVise",new{id=filmID });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
