using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Kino.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nexmo.Api;
using Microsoft.Extensions.Configuration;

namespace Kino.Controllers
{
	public class SMSController : Controller
	{
        private readonly IConfiguration _config;

        public SMSController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
            {
            return View();
            }

            [HttpGet]
            public ActionResult Send()
            {
                return View();
            }
        public ActionResult IzaberiKupca()
        {
            MojDbContext db = new MojDbContext();

            IzaberiKupcaVM model = new IzaberiKupcaVM();
            model.Kupac = db.Korisnici.Where(y => y.BrojTelefona != null).Select(x => new SelectListItem
            {
                Value = x.BrojTelefona,
                Text = x.Ime + " " + x.Prezime
            }).ToList();
            return View("Send",model);
        }
        [HttpPost]
            public IActionResult Send(string text, string to = "38762997236")
            {
               string ApiKey = _config.GetValue<string>("MyConfig:ApiKey");
               string ApiSecret = _config.GetValue<string>("MyConfig:ApiSecret");
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
                {
                    ApiKey = ApiKey,
                    ApiSecret = ApiSecret
            });
                var results = client.SMS.Send(request: new SMS.SMSRequest
                {
                    from = "Uposlenik",
                    to = to,
                    text = text
                });

            return RedirectToAction("", "Home"); ;
            }
    }
}