using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
	public class ProjekcijaAddVM
	{
		public int Id { get; set; }
		public DateTime Pocetak { get; set; }
		public DateTime Kraj { get; set; }
		public double Cijena { get; set; }
		public int FilmID { get; set; }
		public List<SelectListItem> Film { get; set; }
		public int DvoranaID { get; set; }
		public List<SelectListItem> Dvorana { get; set; }

	}
}
