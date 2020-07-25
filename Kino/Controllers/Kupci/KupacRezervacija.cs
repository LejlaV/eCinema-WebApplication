using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Kino.Helper;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using MimeKit;
using MailKit;

namespace Kino.Controllers
{
    [Autorizacija("Kupac")]
    public class KupacRezervacija : Controller
    {
        public IActionResult Dodaj(int ProjekcijaID)
        {
            MojDbContext db = new MojDbContext();
            var projekcija = db.Projekcija.Where(y => y.Id == ProjekcijaID).FirstOrDefault();
            var nazivFilma = db.Projekcija.Where(y => y.Id == ProjekcijaID).Select(y => y.Film.Naziv).FirstOrDefault();
            var dvorana = db.Projekcija.Where(y => y.Id == ProjekcijaID).Select(y => y.Dvorana.Naziv).FirstOrDefault();
            var dvoranaId = db.Projekcija.Where(y => y.Id == ProjekcijaID).Select(y => y.Dvorana.DvoranaID).FirstOrDefault();

            // ovo je u slucaju da je kreirano
            var ukupno = db.projekcijaSjedista.Where(y => y.ProjekcijaID == ProjekcijaID).Distinct().Count();
            var zauzeto = db.projekcijaSjedista.Where(y => y.ProjekcijaID == ProjekcijaID && y.Zauzeto == true).Count();

            if (ukupno == 0)
            {
                if (db.projekcijaSjedista.Where(y => y.ProjekcijaID == ProjekcijaID && y.Zauzeto == false).Any() == false)
                {
                    ukupno = db.Sjedista.Where(y => y.DvoranaID == dvoranaId).Count();
                }
                else
                {
                    ukupno = 0;
                }
            }
            RezervacijaAddVM m = new RezervacijaAddVM() { NazivFilma = nazivFilma, Dvorana = dvorana, Datum = DateTime.Now, ProjekcijaID = ProjekcijaID, Cijena = projekcija.Cijena, DostupanBrojSjedista = ukupno - zauzeto };
            return View(m);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Spasi(RezervacijaAddVM nova)
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            var kupacID = db.Kupac.Where(i => i.KorisnikID == k.KorisnikID).Select(y => y.KupacID).FirstOrDefault();
            var dvoranaid = db.Projekcija.Where(y => y.Id == nova.ProjekcijaID).Select(y => y.DvoranaID).FirstOrDefault();
            var sjedista = db.Sjedista.Where(y => y.DvoranaID == dvoranaid).ToList();
            Rezervacija r = new Rezervacija()
            {
                Datum = nova.Datum,
                brojSjedista = nova.OdabraniBrojSjedista,
                ProjekcijaID = nova.ProjekcijaID,
                KupacID = kupacID,
                UkupnaCijena =nova.Cijena
            };
            db.Add(r);
            db.SaveChanges();


            if (db.projekcijaSjedista.Where(y => y.ProjekcijaID == nova.ProjekcijaID).Any() == false)
            {
                foreach (var item in sjedista)
                {
                    ProjekcijaSjedista ps = new ProjekcijaSjedista { ProjekcijaID = nova.ProjekcijaID, SjedisteID = item.SjedisteID };
                    db.Add(ps);
                    db.SaveChanges();
                }
            }

            var listaPR = db.projekcijaSjedista.Where(y => y.ProjekcijaID == nova.ProjekcijaID && y.Zauzeto == false).ToList();

            int brojac = 0;

            foreach (var item in listaPR)
            {
                if (brojac != nova.OdabraniBrojSjedista)
                {
                    item.Zauzeto = true;
                    item.RezervacijaID = r.Id;
                    db.Update(item);
                    db.SaveChanges();
                }
                else
                {
                    break;
                }
                brojac++;
            }
            db.SaveChanges();

            string KupacMail = db.Korisnici.Where(i => i.KorisnikID == k.KorisnikID).Select(n => n.Email).FirstOrDefault();
            {
                var message = new MimeMessage();
                message.To.Add(new MailboxAddress(KupacMail));
                message.From.Add(new MailboxAddress("eKino2020@outlook.com"));

                message.Subject = "Poruka o rezervaciji";
                message.Body = new TextPart("plain")
                {
                    Text = "Uspješno ste rezervisali sjedišta!"
                };

                using (var client = new SmtpClient())
                {

                    client.Connect("smtp.outlook.com", 587, false);

                    client.Authenticate("eKino2020@outlook.com", "Kino1234");//username i password
                    client.Send(message);
                    client.Disconnect(true);
                }

            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult MojeRezervacije()
        {
            MojDbContext db = new MojDbContext();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            Kupac kupac = db.Kupac.Where(b => b.KorisnikID == k.KorisnikID).FirstOrDefault();
            var lista = db.Rezervacija.Where(y => y.KupacID == kupac.KupacID)
                   .Select(y => new RezervacijaIndex
                   {
                       RezervacijaID = y.Id,
                       DatumRezervacije = y.Datum,
                       Kupac = y.Kupac.Korisnik.Ime + " " + y.Kupac.Korisnik.Prezime,
                       NazivFilma = y.Projekcija.Film.Naziv,
                       OdabraniBrojSjedista = y.brojSjedista,
                       UkupnaCijena = y.UkupnaCijena,
                       Zakljucena = y.Zakljucena,
                       DatumProjekcije = y.Projekcija.Kraj
                   }).ToList()
                   .OrderByDescending(y => y.DatumRezervacije);
            foreach (var item in lista)
            {
                if (item.DatumProjekcije < DateTime.Today)
                {
                    Rezervacija r = db.Rezervacija.Find(item.RezervacijaID);
                    r.Zakljucena = true;
                    db.Update(r);
                    db.SaveChanges();
                }
            }
            return View(lista);
        }
        public IActionResult OtkaziRezervaciju(int RezervacijaID)
        {
            MojDbContext db = new MojDbContext();
            Rezervacija rezervacija = db.Rezervacija.Find(RezervacijaID);

            var listaPR = db.projekcijaSjedista.Where(y => y.RezervacijaID == rezervacija.Id).ToList();
            var dvoranaid = db.Projekcija.Where(y => y.Id == rezervacija.ProjekcijaID).Select(y => y.DvoranaID).FirstOrDefault();
            var sjedista = db.Sjedista.Where(y => y.DvoranaID == dvoranaid).ToList();


            foreach (var item in listaPR)
            {
                item.Zauzeto = false;
                item.RezervacijaID = null;
                db.Update(item);
            }
            db.SaveChanges();
            db.Rezervacija.Remove(rezervacija);
            db.SaveChanges();
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            string KupacMail = db.Korisnici.Where(i => i.KorisnikID == k.KorisnikID).Select(n => n.Email).FirstOrDefault();
            {
                var message = new MimeMessage();
                message.To.Add(new MailboxAddress(KupacMail));
                message.From.Add(new MailboxAddress("eKino2020@outlook.com"));

                message.Subject = "Otkazivanje rezervacije";
                message.Body = new TextPart("plain")
                {
                    Text = "Uspješno ste otkazali Vašu rezervaciju!"
                };

                using (var client = new SmtpClient())
                {

                    client.Connect("smtp.outlook.com", 587, false);

                    client.Authenticate("eKino2020@outlook.com", "Kino1234");//username i password
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            return RedirectToAction("MojeRezervacije");
        }  
    }
}