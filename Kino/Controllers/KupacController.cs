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
    public class KupacController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public KupacController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Prikazi(int TrenutnaStranica = 1, int VelicinaStranice = 6)//svi kupci
        {
            MojDbContext db = new MojDbContext();

            var model = db.Korisnici.Select(b => new KupacIndexVM
            {
                BrojTelefona = b.BrojTelefona,
                Datum = b.DatumRodjenja,
                Ime = b.Ime,
                Prezime = b.Prezime,
                KorisnikId = b.KorisnikID,
                KupacId = db.Kupac.Where(i => i.KorisnikID == b.KorisnikID).Select(b => b.KupacID).FirstOrDefault(),
                NazivGrada = b.Grad.Naziv
            });
            TempData["trenutna"] = TrenutnaStranica;
            var items = model.OrderBy(x => x.Ime).Skip((TrenutnaStranica - 1) * VelicinaStranice).Take(VelicinaStranice).ToList();
            //   db.Dispose();
            return PartialView(items);
        }
       
    }
}