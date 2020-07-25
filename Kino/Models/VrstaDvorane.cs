using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
	public class VrstaDvorane
	{
		[Key]
		public int VrstaDvoraneID { get; set; }
		public string Naziv { get; set; }
	}
}
