using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
	public class ProjekcijaEditVM
	{
		public int Id { get; set; }
		public DateTime Pocetak { get; set; }
		public DateTime Kraj { get; set; }
		public double Cijena { get; set; }
		public string Film { get; set; }
		public string Dvorana { get; set; }
	}
}
