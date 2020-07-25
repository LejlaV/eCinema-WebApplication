using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class FilmAddVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Trajanje { get; set; }
        public string DobnoOgraničenje { get; set; }
        public int GodinaIzdavanja { get; set; }
        public string Sinopsis { get; set; }
        public bool Aktuelan { get; set; }
        public List<SelectListItem> Zanr { get; set; }
        public int[] Zanrovi { get; set; }
        public List<SelectListItem> Reziser { get; set; }
        public int[] Reziseri { get; set; }
        public List<SelectListItem> Glumac { get; set; }
        public int[] Glumci { get; set; }
        public string putanjaSlike { get; set; }
        public IFormFile Slika { get; set; }
        public string  Trailer { get; set; }
    }
}
