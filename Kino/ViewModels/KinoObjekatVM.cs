using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
	public class KinoObjekatVM
	{
		public int KinoID { get; set; }
		public string Naziv { get; set; }
		public List<SelectListItem> Adresa { get; set; }
		public int AdresaId { get; set; }
	}
}
