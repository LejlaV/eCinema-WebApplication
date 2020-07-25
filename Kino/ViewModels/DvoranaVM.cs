using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
	public class DvoranaVM
	{
		public int DvoranaID { get; set; }
		public string Naziv { get; set; }
		public string Opis { get; set; }
		public List<SelectListItem> VrstaDvorane { get; set; }
		public int VrstaDvoraneID { get; set; }
		public List<SelectListItem> KinoObjekat { get; set; }
		public int KinoObjekatID { get; set; }
        public int OdabraniKapacitet { get; set; }
        // public List<SelectListItem> Kapacitet { get; set; } 
        public List<SelectListItem> BrojRedova { get; set; }
        public int OdabraniBrojRedova { get; set; }
        public List<SelectListItem> BrojKolona { get; set; }
        public int OdabraniBrojKolona { get; set; }

        public DvoranaVM()
        {
            BrojRedova = new List<SelectListItem>();
            BrojRedova.Add(new SelectListItem { Text = "10", Value = "10" });
            BrojRedova.Add(new SelectListItem { Text = "11", Value = "11" });
            BrojRedova.Add(new SelectListItem { Text = "12", Value = "12" });
            BrojRedova.Add(new SelectListItem { Text = "13", Value = "13" });
            BrojRedova.Add(new SelectListItem { Text = "14", Value = "14" });
            BrojRedova.Add(new SelectListItem { Text = "15", Value = "15" });

            BrojKolona = new List<SelectListItem>();
            BrojKolona.Add(new SelectListItem { Text = "10", Value = "10" });
            BrojKolona.Add(new SelectListItem { Text = "11", Value = "11" });
            BrojKolona.Add(new SelectListItem { Text = "12", Value = "12" });
            BrojKolona.Add(new SelectListItem { Text = "13", Value = "13" });
            BrojKolona.Add(new SelectListItem { Text = "14", Value = "14" });
            BrojKolona.Add(new SelectListItem { Text = "15", Value = "15" });

        }
    }
}
