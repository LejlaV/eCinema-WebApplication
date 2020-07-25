using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
	public class FilmOcjena
	{
		public int ID { get; set; }
		public float? Ocjena { get; set; }
		public float? prosjecnaOcjena { get; set; }
		public Film Film { get; set; }
		public int FilmID { get; set; }
		public Kupac Kupac { get; set; }
		public int KupacID { get; set; }
	}
}
