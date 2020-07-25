using Kino.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class KupacUrediProfil
    {
        public int KupacId { get; set; }
        public int KorisnikId { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public List<SelectListItem> grad { get; set; }
        public int GradId { get; set; }
        public string Email { get; set; }
        public string putanja { get; set; }
        public IFormFile Slika { get; set; }
   
    }
}
