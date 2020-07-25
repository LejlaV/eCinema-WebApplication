using Kino.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Kino.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kino.ViewModels
{
    public class RegistracijaIndexVM
    {

        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Ime sadrži samo  slova")]
        [StringLength(20, ErrorMessage = "Ime mora sadržavati minimalno 3 karaktera.", MinimumLength = 4)] 
        [Required(ErrorMessage = "Ime je obavezno polje")]
        public string Ime { get; set; }
       

        [StringLength(25, ErrorMessage = "Prezime mora sadržavati minimalno 3 karaktera.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Prezime sadrži samo slova")]  
        [Required(ErrorMessage = "Prezime je obavezno polje")]
        public string Prezime { get; set; }
      


        [StringLength(10, ErrorMessage = "Broj telefona mora sadržavati najmanje 9 karaktera.", MinimumLength = 9)] 
        [Required(ErrorMessage = "Broj je obavezno polje")]
        public string BrojTelefona { get; set; }
       

        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Mail mora biti u ispravnom formatu")]
        
       [Required(ErrorMessage ="Email je obavezno polje")]
        public string Email { get; set; }
     
        public int Uloga { get; set; }


        [ForeignKey("GradID")]
        [Required(ErrorMessage = "Grad je obavezno polje")]
        public List<SelectListItem> gradovi { get; set; }
        public int GradID { get; set; }

        [StringLength(20, ErrorMessage = "Username mora sadržavati najmanje 20 karaktera.", MinimumLength = 4)]
        [Required(ErrorMessage = "Username je obavezno polje")]
        public string UserName { get; set; }


        [StringLength(20, ErrorMessage = "Password mora sadržavati minimalno 4 karaktera.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password je obavezno polje")]
        public string Password { get; set; }

    }
}