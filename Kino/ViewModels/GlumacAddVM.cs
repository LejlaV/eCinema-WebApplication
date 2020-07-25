using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class GlumacAddVM
    {
        public int GlumacID { get; set; }
        [Required(ErrorMessage = "Morate unijeti vrijednost")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Morate unijeti minimalno 3 slova!")]
        [RegularExpression("/^([a-zA-Z])$/", ErrorMessage = "Ime moze sadrzavati samo tekstualne podatke!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Morate unijeti vrijednost")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Morate unijeti minimalno 3 slova!")]
        [RegularExpression("/^([a-zA-Z])$/", ErrorMessage = "Prezime moze sadrzavati samo tekstualne podatke!")]
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public List<SelectListItem> Grad { get; set; }
        public string MjestoRodjenja { get; set; }
        public int GradID { get; set; }
        public string putanjaSlike { get; set; }
        public IFormFile Slika { get; set; }
    }
}
