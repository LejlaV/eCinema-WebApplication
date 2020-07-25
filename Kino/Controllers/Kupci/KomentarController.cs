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
    public class KomentarController : Controller
    {
        [HttpPost]
        public JsonResult OstaviteKomentar(KomentarVM model)
        {
            MojDbContext db = new MojDbContext(); 
            JsonResult result;
            try
            {
                Korisnik k = HttpContext.GetLogiraniKorisnik();
                int m = db.Kupac.Where(u => u.KorisnikID == k.KorisnikID).Select(n => n.KupacID).FirstOrDefault();
                Komentar h = new Komentar();
                var komentar = new Komentar();
                komentar.Sadrzaj = model.Text;
                komentar.ObjavaId = model.ObjavaId;
                komentar.KupacId = m;
                komentar.Datum = DateTime.Now;
                var res = h.Dodaj(komentar);
               // throw new Exception("Dogodila se greska");
                result = new JsonResult(new { success = true});
            }
            catch(Exception ex)
            {
                result = new JsonResult(new { success = false, Message=ex.Message }); 
            }
            return result;
        }
    }
}