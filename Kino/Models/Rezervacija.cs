using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double UkupnaCijena { get; set; }
        public int brojSjedista { get; set; }
        [ForeignKey("Projekcija")]
        public int ProjekcijaID { get; set; }
        public virtual Projekcija Projekcija { get; set; }
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public virtual Kupac Kupac { get; set; }
        public bool Zakljucena { get; set; }
      

    }
}
