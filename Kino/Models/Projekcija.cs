using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
	public class Projekcija
	{
		public int Id { get; set; }
		public DateTime Pocetak { get; set; }
		public DateTime Kraj { get; set; }
		public double Cijena { get; set; }

		[ForeignKey("Dvorana")]
		public int DvoranaID { get; set; }
		public Dvorana Dvorana { get; set; }

		[ForeignKey("Film")]
		public int FilmID { get; set; }
		public virtual Film Film { get; set; }
	}
}
