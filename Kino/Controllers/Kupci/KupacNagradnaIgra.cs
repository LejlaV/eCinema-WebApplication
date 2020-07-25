using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Helper;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Controllers
{
    [Autorizacija("Kupac")]
    public class KupacNagradnaIgra : Controller
    {
        public IActionResult Index()
        {
            MojDbContext _db = new MojDbContext();
            List<NagradnaIgra> o = _db.NagradnaIgra.ToList();
            return View(o);
        }
        public IActionResult PrikaziVise(int NagradnaIgraID)
        {
            MojDbContext db = new MojDbContext();
            KupacNagradnaIgraPrikaziViseVM model = db.NagradnaIgra.Where(i => i.NagradnaIgraID == NagradnaIgraID).Select(n => new KupacNagradnaIgraPrikaziViseVM
            {
                NagradnaId = n.NagradnaIgraID,
                Sadrzaj = n.Opis,
                Naziv = n.Naziv,
                Kraj = n.Kraj,
                Početak = n.Pocetak
            }).FirstOrDefault();
            return View(model);
        }
    }
}