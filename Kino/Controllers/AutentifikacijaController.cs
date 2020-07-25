using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Helper;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kino.Controllers
{
    public class AutentifikacijaController : Controller
    {
        public IActionResult Index()
        {
            MojDbContext db = new MojDbContext();
            return View(new LoginVM()
            {
                ZapamtiPassword=true
            });
            
        }
       public  IActionResult Login(LoginVM input)
        {
            MojDbContext db = new MojDbContext();
            Korisnik korisnik = db.Korisnici
                .Include(x => x.Uloga)
                .SingleOrDefault(x => x.UserName == input.Username);
            if(!(korisnik.PasswordHash == Criptography.Hash.Create(input.Password,korisnik.PasswordSalt)))
            { 
                ViewData["error-poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }
            // HttpContext.Session.SetString("nekiKey", korisnik.Username);
           // HttpContext.Session.Set("logirani_korisnik", korisnik);
            HttpContext.SetLogiraniKorisnik(korisnik);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}