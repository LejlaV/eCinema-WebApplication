using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;
using Kino.ViewModels;
using PagedList;
using PagedList.Mvc;
using Rotativa.AspNetCore;

namespace Kino.Controllers
{
    public class ZanrController : Controller
    {
        
        public IActionResult Index(string poruka,string poruka1,int?page)
        {
            MojDbContext db = new MojDbContext();
            var z = db.Zanr.Select(y => new ZanrAddVM
            {
                ZanrID = y.ZanrID,
                Naziv = y.Naziv,
                Opis = y.Opis

            }).ToPagedList(page??1,3);
            ViewData["poruka-kljuc"] = poruka;
            ViewData["poruka1-kljuc"] = poruka1;

            return View("Index",z);
        }
        public IActionResult Obrisi(int id)
        {
            MojDbContext db = new MojDbContext();
            Zanr z = db.Zanr.Find(id);
            if (z != null)
            {
                db.Remove(z);
                db.SaveChanges();
            }
            else
            {
                return Redirect("/Zanr?poruka1 = Ne postoji trazeni zanr!");
            }
           return Redirect("/Zanr?poruka=Uspjesno ste obrisali zanr!");       
        }
        public IActionResult Dodaj(int id)
        {
            MojDbContext db = new MojDbContext();
            if (id != 0)
            {
                ZanrAddVM a = new ZanrAddVM
                {
                    ZanrID = db.Zanr.Find(id).ZanrID,
                    Naziv = db.Zanr.Find(id).Naziv,
                    Opis = db.Zanr.Find(id).Opis
                };
                return View("DodajForm", a);
            }
            else
            {
                ZanrAddVM n = new ZanrAddVM();
                return View("DodajForm", n);

            }
        }

        public IActionResult DodajSnimi(ZanrAddVM zv)
        {
            MojDbContext db = new MojDbContext();
            if (db.Zanr.Find(zv.ZanrID) != null)
            {
                db.Zanr.Find(zv.ZanrID).Naziv = zv.Naziv;
                db.Zanr.Find(zv.ZanrID).Opis = zv.Opis;
                db.SaveChanges();
                return Redirect("/Zanr?poruka=Uspjesno ste uredili zanr!");
            }
            else
            {
                if (Postoji(zv.Naziv) == true)
                    return Redirect("/Zanr/?poruka1=Zanr vec postoji!");
                Zanr z = new Zanr { Naziv = zv.Naziv, Opis = zv.Opis };
                db.Add(z);
                db.SaveChanges();
                db.Dispose();
                return Redirect("/Zanr/?poruka=Uspjesno ste dodali zanr!");

            }
        }

        public bool Postoji(string Naziv)
        {
            MojDbContext db = new MojDbContext();
            List<Zanr> zx = db.Zanr.ToList();
            foreach(var z in zx)
            {
                if(String.Compare(Naziv,z.Naziv)==0)
                {
                    return true; 
                }
            }
            return false;
        }
      
       

    }
}