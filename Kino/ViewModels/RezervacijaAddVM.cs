using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class RezervacijaAddVM
    {
        public int RezervacijaID { get; set; }
        public string NazivFilma { get; set; }
        public string Dvorana { get; set; }
        public DateTime Datum { get; set; }
        public int ProjekcijaID { get; set; }
        public int DostupanBrojSjedista { get; set; }
        public double  Cijena { get; set; }
        public List<SelectListItem> BrojSjedista { get; set; }
        public int OdabraniBrojSjedista { get; set; }
        public RezervacijaAddVM()
        {
            BrojSjedista = new List<SelectListItem>();
            BrojSjedista.Add(new SelectListItem { Text = "1", Value = "1" });
            BrojSjedista.Add(new SelectListItem { Text = "2", Value = "2" });
            BrojSjedista.Add(new SelectListItem { Text = "3", Value = "3" });
            BrojSjedista.Add(new SelectListItem { Text = "4", Value = "4" });
            BrojSjedista.Add(new SelectListItem { Text = "5", Value = "5" });


        }
    }
}
