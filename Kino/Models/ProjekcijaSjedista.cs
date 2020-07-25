using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class ProjekcijaSjedista
    {
        public int Id { get; set; }
        [ForeignKey("Projekcija")]
        public int ProjekcijaID { get; set; }
        public virtual Projekcija Projekcija { get; set; }

        [ForeignKey("Film")]
        public int SjedisteID { get; set; }
        public virtual Sjediste Sjediste { get; set; }
        public bool Zauzeto { get; set; }
        [ForeignKey("Rezervacija")]
        public int? RezervacijaID { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
