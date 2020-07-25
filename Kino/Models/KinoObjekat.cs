using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
	public class KinoObjekat
	{
		[Key]
		public int KinoID { get; set; }
		public string Naziv { get; set; }

		[ForeignKey("Adresa")]
		public int AdresaId { get; set; }
		public Adresa Adresa { get; set; }
	}
}
