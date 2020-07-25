using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kino.ViewModels;
using Kino.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Kino.Controllers
{
    public class ProjekcijaController : Controller
    {
        MojDbContext db = new MojDbContext();

        public IActionResult Index(int MovieID)
        {
            ProjekcijaIndexVM model = new ProjekcijaIndexVM();
            try
            {
                if (MovieID != 0)
                {
                    model.rows = db.Projekcija.Where(y => y.FilmID == MovieID).Select(x => new ProjekcijaIndexVM.Row()
                    {
                        Id = x.Id,
                        Pocetak = x.Pocetak,
                        Kraj = x.Kraj,
                        Cijena = x.Cijena,
                        Film = x.Film.Naziv,
                        Dvorana = x.Dvorana.Naziv
                    }).ToList();
                    return View(model);

                }
                else
                {

                    model.rows = db.Projekcija.Select(x => new ProjekcijaIndexVM.Row()
                    {
                        Id = x.Id,
                        Pocetak = x.Pocetak,
                        Kraj = x.Kraj,
                        Cijena = x.Cijena,
                        Film = x.Film.Naziv,
                        Dvorana = x.Dvorana.Naziv
                    }).ToList();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(model);
            }
            //ProjekcijaIndexVM model = new ProjekcijaIndexVM()
            //{
            //    rows = db.Projekcija.Select(x => new ProjekcijaIndexVM.Row()
            //    {
            //        Id = x.Id,
            //        Pocetak = x.Pocetak,
            //        Kraj = x.Kraj,
            //        Cijena = x.Cijena,
            //        Film = x.Film.Naziv,
            //        Dvorana=x.Dvorana.Naziv
            //    }).ToList()
            //};
            //db.Dispose();
            //return View(model);
        }

        public IActionResult Add()
        {
            MojDbContext db = new MojDbContext();
            
            try
            {
                ProjekcijaAddVM model = new ProjekcijaAddVM()
                {
                    Film = db.Film.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Naziv
                    }).ToList(),

                    Dvorana = db.Dvorana.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                    {
                        Value = x.DvoranaID.ToString(),
                        Text = x.Naziv
                    }).ToList()
                };
                db.Dispose();
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Greška prilikom dodavanja projekcije! " });
            }
        }

        public IActionResult Save(ProjekcijaAddVM model)
        {
            MojDbContext db = new MojDbContext();

            try
            {
                Projekcija novaProjekcija = new Projekcija()
                {
                    FilmID = model.FilmID,
                    DvoranaID = model.DvoranaID,
                    Pocetak = model.Pocetak,
                    Kraj = model.Kraj,
                    Cijena = model.Cijena
                };
                db.Projekcija.Add(novaProjekcija);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {

                return Json(new { status = "error", message = "Greška prilikom snimanja projekcije! " });

            }
        }

        public IActionResult Edit(int ProjekcijaID)
        {
            MojDbContext db = new MojDbContext();

            Projekcija projekcija = db.Projekcija.Where(x => x.Id == ProjekcijaID)
                                                 .Include(x => x.Film)
                                                 .Include(x => x.Dvorana)
                                                 .FirstOrDefault();
            try
            {
                ProjekcijaEditVM model = new ProjekcijaEditVM()
                {
                    Id = projekcija.Id,
                    Dvorana = projekcija.Dvorana.Naziv,
                    Film = projekcija.Film.Naziv,
                };
                db.Dispose();
                return View(model);
            }

            catch (Exception ex)
            {

                return Json(new { status = "error", message = "Greška prilikom editovanja projekcije! " });

            }
        }

        public IActionResult SaveEdit(ProjekcijaEditVM model)
        {
            MojDbContext db = new MojDbContext();

            try
            {
                Projekcija projekcija = db.Projekcija.Where(x => x.Id == model.Id)
                                                 .Include(x => x.Film)
                                                 .Include(x => x.Dvorana)
                                                 .FirstOrDefault();
                projekcija.Pocetak = model.Pocetak;
                projekcija.Kraj = model.Kraj;
                projekcija.Cijena = model.Cijena;
                db.Projekcija.Update(projekcija);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {

                return Json(new { status = "error", message = "Greška prilikom snimanja promjena projekcije! " });

            }
        }

        public IActionResult Obrisi (int ProjekcijaID)
        {
            MojDbContext db = new MojDbContext();
            
            try
            {
                Projekcija projekcija = db.Projekcija.Where(x => x.Id == ProjekcijaID)
                                                 .FirstOrDefault();
                db.Projekcija.Remove(projekcija);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Graška: nije moguće ukloniti projekciju! " });
            }
        }
    }
}