using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
	public class Dvorana
	{
		[Key]
		public int DvoranaID { get; set; }
		public string Naziv { get; set; }
		public string Opis { get; set; }

		[ForeignKey("VrstaDvorane")]
		public int VrstaDvoraneID { get; set; }
		public VrstaDvorane VrstaDvorane { get; set; }

		[ForeignKey("KinoObjekat")]
		public int KinoObjekatID { get; set; }
		public KinoObjekat KinoObjekat { get; set; }
        public int Kapacitet { get; set; }
      
    }
}
