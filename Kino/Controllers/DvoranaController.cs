using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kino.Controllers
{
    public class DvoranaController : Controller
    {
        public IActionResult Index(string dv)
        {
			MojDbContext db = new MojDbContext();
			List<Dvorana> dvorane = db.Dvorana.Include(x => x.VrstaDvorane)
											  .Include(x => x.KinoObjekat).ToList();
			ViewData["dvorane"] = dv;
            return View(dvorane);
        }
		public IActionResult DodajUrediForma()
		{
			MojDbContext db = new MojDbContext();
			DvoranaVM model = new DvoranaVM();
			model.VrstaDvorane = db.VrstaDvorane.Select(x => new SelectListItem(x.Naziv, x.VrstaDvoraneID.ToString())).ToList();
			model.KinoObjekat = db.KinoObjekat.Select(x => new SelectListItem(x.Naziv, x.KinoID.ToString())).ToList();
			return View("DodajUrediForma", model);	
  }
		public IActionResult DodajSnimi(DvoranaVM model)
		{
            
			MojDbContext db = new MojDbContext();
			Dvorana d;

			if (model.DvoranaID == 0)
			{
				d = new Dvorana();
				db.Add(d);
			}
			else
			{
				d = db.Dvorana.Find(model.DvoranaID);
				d.DvoranaID = model.DvoranaID;
			}
			d.Naziv = model.Naziv;
			d.Opis = model.Opis;
			d.VrstaDvoraneID = model.VrstaDvoraneID;
			d.KinoObjekatID = model.KinoObjekatID;
			db.SaveChanges();
            bool isto = false;
            var DvoranaID = db.Dvorana.Where(d => d.Naziv == model.Naziv).FirstOrDefault().DvoranaID;
            if (model.DvoranaID != 0)
            {
                var pocetniBrojRedova = db.Sjedista.Where(y => y.DvoranaID == DvoranaID).Select(y => y.Red).Distinct().ToList();
                var pocetniBrojKolona = db.Sjedista.Where(y => y.DvoranaID == DvoranaID).Select(y => y.Kolona).Distinct().ToList();
                
                if (pocetniBrojRedova.Count() != model.OdabraniBrojRedova || pocetniBrojKolona.Count() != model.OdabraniBrojKolona)
                {
                    ObrisiSjedista(DvoranaID);
                }
                else if(pocetniBrojRedova.Count() == model.OdabraniBrojRedova || pocetniBrojKolona.Count() == model.OdabraniBrojKolona)
                {
                    isto = true;
                    d.Kapacitet = pocetniBrojRedova.Count() * pocetniBrojKolona.Count();
                }
            }
            if (isto != true)
            {
                DodajSjedista(model);
                d.Kapacitet = model.OdabraniBrojRedova * model.OdabraniBrojKolona;
            }
            db.SaveChanges();
			TempData["porukasuccess"] = "Uspjesno ste dodali novu dvoranu!";
			return RedirectToAction(nameof(Index));
		}
		
		public IActionResult Uredi(int DvoranaID)
		{
			//if (DvoranaID == null)
			//{
			//	return RedirectToAction(nameof(Index));
			//}
			MojDbContext db = new MojDbContext();
			Dvorana dvorana = db.Dvorana.Find(DvoranaID);
			if (dvorana == null)
			{
				return RedirectToAction(nameof(Index));
			}
			DvoranaVM model = new DvoranaVM();
			model.DvoranaID = dvorana.DvoranaID;
			model.Naziv = dvorana.Naziv;
			model.Opis = dvorana.Opis;
			model.VrstaDvorane = db.VrstaDvorane.Select(x => new SelectListItem(x.Naziv, x.VrstaDvoraneID.ToString())).ToList();
			model.VrstaDvoraneID = dvorana.VrstaDvoraneID;
			model.KinoObjekat = db.KinoObjekat.Select(x => new SelectListItem(x.Naziv, x.KinoID.ToString())).ToList();
			model.KinoObjekatID = dvorana.KinoObjekatID;
            var redovi = db.Sjedista.Where(y => y.DvoranaID == DvoranaID).Select(y => y.Red).ToList().Distinct();
            model.OdabraniBrojRedova=redovi.Count();
            var kolone = db.Sjedista.Where(y => y.DvoranaID == DvoranaID).Select(y => y.Kolona).ToList().Distinct();
            model.OdabraniBrojKolona = kolone.Count();

            return View("DodajUrediForma", model);
		}
		public IActionResult Obrisi (int DvoranaID)
		{
			MojDbContext db = new MojDbContext();
            ObrisiSjedista(DvoranaID);
			Dvorana d = db.Dvorana.FirstOrDefault(x => x.DvoranaID == DvoranaID);
			if (d == null)
			{
				TempData["porukaerror"] = "Nije moguce obrisati!";
			}
			db.Remove(d);
			db.SaveChanges();
			db.Dispose();
			TempData["porukasuccess"] = "Uspjesno obrisano!";
			return RedirectToAction(nameof(Index));
			}
        public void ObrisiSjedista(int DvoranaID)
        {
            MojDbContext db = new MojDbContext();
            var lista = db.Sjedista.Where(y => y.DvoranaID == DvoranaID).ToList();
            foreach (var item in lista)
            {
                db.Remove(item);
            }
            db.SaveChanges();

        }
        public void DodajSjedista(DvoranaVM model)
        {
            MojDbContext db = new MojDbContext();
            var DvoranaID = db.Dvorana.Where(d => d.Naziv == model.Naziv).FirstOrDefault().DvoranaID;

            for (int i = 0; i < model.OdabraniBrojRedova; i++)
            {
                for (int j = 0; j < model.OdabraniBrojKolona; j++)
                {
                    db.Sjedista.Add(new Sjediste
                    {
                        DvoranaID = DvoranaID,
                        Red = ((char)(i + 65)).ToString(),
                        Kolona = j + 1
                    });
                }
            }
            db.SaveChanges();

        }
    }
}