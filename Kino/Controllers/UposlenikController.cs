using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers
{
	public class UposlenikController : Controller
	{
		private readonly IWebHostEnvironment hostingEnvironment;

		public UposlenikController(IWebHostEnvironment hostingEnvironment)
		{
			this.hostingEnvironment = hostingEnvironment;
		}
		public IActionResult Index()
		{
			MojDbContext db = new MojDbContext();
			List<Korisnik> uposlenici = db.Korisnici
                .Where(y=>y.Uloga.Naziv.Contains("Uposlenik"))
                .Include(x => x.Grad).Include(x => x.Uloga).ToList();
			return View(uposlenici);
		}
		public IActionResult DodajUrediForma()
		{
			MojDbContext db = new MojDbContext();
			UposlenikVM model = new UposlenikVM();
			model.Grad = db.Grad.Select(x => new SelectListItem(x.Naziv, x.GradID.ToString())).ToList();
			//model.KorisnickaUloga = db.Uloge.Select(x => new SelectListItem(x.Naziv, x.UlogaID.ToString())).ToList();
			return View("DodajUrediForma", model);
		}

		public IActionResult DodajSnimi(UposlenikVM model)
		{
			MojDbContext db = new MojDbContext();

			string uniqueFileName = null;

			if (ModelState.IsValid)
			{
				if (model.Slika != null)
				{
					string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
					uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
					string filePath = Path.Combine(uploadsFolder, uniqueFileName);
					model.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
				}
			}

			Korisnik noviUposlenik;
			if (model.UposlenikID == 0)
			{
				noviUposlenik = new Korisnik();
				db.Add(noviUposlenik);
			}
			else
			{
				noviUposlenik = db.Korisnici.Find(model.UposlenikID);
				noviUposlenik.KorisnikID = model.UposlenikID;
			}
			noviUposlenik.Ime = model.Ime;
			noviUposlenik.Prezime = model.Prezime;
			noviUposlenik.UserName = model.KorisnickoIme;
			noviUposlenik.Email = model.Email;
			noviUposlenik.DatumRodjenja = model.DatumRodjenja;
			noviUposlenik.GradID = model.GradID;
			noviUposlenik.UlogaID = 2; //TODO: Uzimati sa forme
			noviUposlenik.Slika = uniqueFileName;
			db.SaveChanges();
			db.Dispose();
			TempData["porukasuccess"] = "Uspjesno ste dodali novog uposlenika!";
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Uredi(int UposlenikID, string putanja)
		{
			if (UposlenikID == 0)
			{
				return RedirectToAction(nameof(Index));
			}
			MojDbContext db = new MojDbContext();
			Korisnik uposlenik = db.Korisnici.Find(UposlenikID);
			if (uposlenik == null)
			{
				return RedirectToAction(nameof(Index));
			}
			UposlenikVM model = new UposlenikVM();
			model.UposlenikID = uposlenik.KorisnikID;
			model.Ime = uposlenik.Ime;
			model.Prezime = uposlenik.Prezime;
			model.DatumRodjenja = uposlenik.DatumRodjenja;
			model.Email = uposlenik.Email;
			model.Grad = db.Grad.Select(x => new SelectListItem(x.Naziv, x.GradID.ToString())).ToList();
			model.GradID = uposlenik.GradID.Value; //TODO: Promjeniti postaviti da grad nije NULL
			model.KorisnickaUloga = db.Uloge.Select(x => new SelectListItem(x.Naziv, x.UlogaID.ToString())).ToList();
			model.KorisnickaUlogaID = uposlenik.UlogaID;
			model.putanjaSlike = putanja;
			return View("DodajUrediForma", model);
		}
		public IActionResult Obrisi(int UposlenikID)
		{
			MojDbContext db = new MojDbContext();
			Korisnik uposlenik = db.Korisnici.FirstOrDefault(x => x.KorisnikID == UposlenikID);
			if (uposlenik == null)
			{
				TempData["porukaerror"] = "Nije moguce obrisati!";
				return RedirectToAction(nameof(Index));
			}
			db.Remove(uposlenik);
			db.SaveChanges();
			db.Dispose();
			TempData["porukasuccess"] = "Uspjesno obrisano!";
			return RedirectToAction(nameof(Index));
		}
	}
}