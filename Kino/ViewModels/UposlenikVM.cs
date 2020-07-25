using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class UposlenikVM
    {
        public int UposlenikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public List<SelectListItem> Grad { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> KorisnickaUloga { get; set; }
        public int KorisnickaUlogaID { get; set; }
        public string putanjaSlike { get; set; }
        public IFormFile Slika { get; set; }
        public UposlenikVM()
        {
            KorisnickaUloga = new List<SelectListItem>();
            KorisnickaUloga.Add(new SelectListItem { Text = "Uposlenik", Value = "2" });
           


        }




    }
    

}

