using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
	public class ZaposlenikProfilVM
	{
        public int UposlenikID { get; set; }
        public string ImePrezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Grad { get; set; }
        public string KorisnickaUloga { get; set; }
        public string putanjaSlike { get; set; }
        public IFormFile Slika { get; set; }
    }
}
