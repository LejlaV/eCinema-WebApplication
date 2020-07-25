using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Kino.Helper;

namespace Kino.Helper
{
    public static class Autentifikacija
    {
        public static readonly string LogiraniKorisnik = "logirani_korisnik";

        public static Korisnik GetLogiraniKorisnik(this HttpContext context)
        {
            Korisnik korisnik = context.Request.GetCookieJson<Korisnik>(LogiraniKorisnik);

            if (korisnik == null)
                return null;

            return korisnik;
        }
        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }
        public static void SetLogiraniKorisnik(this HttpContext context, Korisnik korisnik, bool snimiUCookie = false)
        {
            // context.Session.Set(LogiraniKorisnik, korisnik);
            MojDbContext db = context.RequestServices.GetService<MojDbContext>();

            context.Response.SetCookieJson(LogiraniKorisnik, korisnik);
        }

    }
}