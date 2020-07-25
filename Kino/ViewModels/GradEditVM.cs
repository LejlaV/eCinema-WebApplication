using Kino.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class GradEditVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PostanskiBroj { get; set; }
        public List<SelectListItem> Drzava { get; set; }
        public int DrzavaID { get; set; }
    }
}
