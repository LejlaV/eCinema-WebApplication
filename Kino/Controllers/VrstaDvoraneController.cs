using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace Kino.Controllers
{
	public class VrstaDvoraneController : Controller
	{
		public IActionResult Index(string porukasuccess, string porukaerror, int? page)
		{
			MojDbContext db = new MojDbContext();
			List<VrstaDvorane> vrste = db.VrstaDvorane.ToList();
			ViewData["vrste-kljuc"] = vrste;
			ViewData["porukasuccess"] = porukasuccess;
			ViewData["porukaerror"] = porukaerror;
			return View(vrste.ToPagedList(page ?? 1, 3));
		}
		public IActionResult DodajForma()
		{
			VrstaDvoraneVM vm = new VrstaDvoraneVM();
			return View("DodajUrediForma", vm);
		}
		public IActionResult DodajSnimi(VrstaDvoraneVM vm)
		{
			MojDbContext db = new MojDbContext();
			VrstaDvorane vd;
			if (vm.VrstaDvoraneID == 0)
			{
				vd = new VrstaDvorane();
				db.Add(vd);
			}
			else
			{
				vd = db.VrstaDvorane.Find(vm.VrstaDvoraneID);
				vd.VrstaDvoraneID = vm.VrstaDvoraneID;
				if (DaLiPostoji(vm.Naziv) == true)
				{
					return Redirect("/VrstaDvorane/?porukaerror=Vrsta dvorane vec postoji!");
				}
			}
			vd.Naziv = vm.Naziv;
			db.SaveChanges();
			db.Dispose();
			return Redirect("/VrstaDvorane/?porukasuccess=Uspjesno ste dodali novu vrstu dvorane!");
		}

		public bool DaLiPostoji(string Naziv)
		{
			MojDbContext db = new MojDbContext();
			List<VrstaDvorane> vrste = db.VrstaDvorane.ToList();
			foreach (var v in vrste)
			{
				if (String.Compare(Naziv, v.Naziv) == 0)
				{
					return true;
				}
			}
			return false;
		}

		public IActionResult Uredi(int VrstaDvoraneID)
		{
			if (VrstaDvoraneID == 0)
			{
				return RedirectToAction(nameof(Index));
			}

			MojDbContext db = new MojDbContext();
			VrstaDvorane vd = db.VrstaDvorane.Find(VrstaDvoraneID);
			if (vd == null)
			{
				return RedirectToAction(nameof(Index));
			}

			VrstaDvoraneVM vm = new VrstaDvoraneVM();
			vm.VrstaDvoraneID = vd.VrstaDvoraneID;
			vm.Naziv = vd.Naziv;
			return View("DodajUrediForma", vm);
		}
		public ActionResult Obrisi(int VrstaDvoraneID)
		{
			MojDbContext db = new MojDbContext();
			VrstaDvorane vd = db.VrstaDvorane.Where(x => x.VrstaDvoraneID == VrstaDvoraneID).FirstOrDefault();
			if (vd == null)
			{
				return Content("/VrstaDvorane/?porukaerror=Nije moguce obrisati! Vrsta dvorane ne postoji!");
			}
			db.Remove(vd);
			db.SaveChanges();
			db.Dispose();
			return RedirectToAction(nameof(Index));
		}

	}
}