using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kino.Models;


namespace Kino.Controllers
{
	public class KinoObjekatController : Controller
	{
		public IActionResult Index(string poruka)
		{
			MojDbContext db = new MojDbContext();
			List<KinoObjekat> kina = db.KinoObjekat.Include(x => x.Adresa).ToList();
			ViewData["kina"] = poruka;
			
			return View(kina);
		}
		public IActionResult DodajForma()
		{
			MojDbContext db = new MojDbContext();
			KinoObjekatVM vm = new KinoObjekatVM();
			vm.Adresa = db.Adresa.Select(x => new SelectListItem(x.NazivUlice, x.AdresaID.ToString())).ToList();
			return View("DodajUrediForma", vm);
		}
		public IActionResult Uredi(int KinoObjekatID)
		{
			if (KinoObjekatID == null)
			{
				return RedirectToAction(nameof(Index));
			}
			MojDbContext db = new MojDbContext();
			KinoObjekat kino = db.KinoObjekat.Find(KinoObjekatID);
			if (kino == null)
			{
				return RedirectToAction(nameof(Index));
			}
			KinoObjekatVM vm = new KinoObjekatVM();
			vm.Adresa = db.Adresa.Select(x => new SelectListItem(x.NazivUlice, x.AdresaID.ToString())).ToList();
			vm.AdresaId = kino.AdresaId;
			vm.KinoID = kino.KinoID;
			vm.Naziv = kino.Naziv;
			return View("DodajUrediForma", vm);
		}
		public IActionResult DodajSnimi(KinoObjekatVM kino)
		{
			MojDbContext db = new MojDbContext();
			KinoObjekat k;

			if (kino.KinoID==0)
			{
				k = new KinoObjekat();
				db.Add(k);
			}
			else
			{
				k = db.KinoObjekat.Find(kino.KinoID);
				k.KinoID = kino.KinoID;
			}
			k.Naziv = kino.Naziv;
			k.AdresaId = kino.AdresaId;
			db.SaveChanges();
			db.Dispose();
			TempData["porukasuccess"] = "Uspjesno ste dodali kino!";
			return RedirectToAction(nameof(Index));
		}
		bool DaLiPostoji(string Naziv)
		{
			MojDbContext db = new MojDbContext();
			List<KinoObjekat> kina = db.KinoObjekat.ToList();

			if (kina.Any(x => String.Compare(x.Naziv, Naziv) == 0))
			{
				return true;
			}
			return false;
		}
		public IActionResult Obrisi(int KinoObjekatID)
		{
			MojDbContext db = new MojDbContext();
			KinoObjekat kino = db.KinoObjekat.FirstOrDefault(x => x.KinoID == KinoObjekatID);
			if (kino == null)
			{
				TempData["porukaerror"] = "Nije moguce obrisati!";
			}
			db.Remove(kino);
			db.SaveChanges();
			db.Dispose();
			TempData["porukasuccess"] = "Uspjesno obrisano!";
			return RedirectToAction(nameof(Index));
		}
	}
}