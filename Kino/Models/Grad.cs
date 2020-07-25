using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Grad
    {   [Key]
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public int PostanskiBroj { get; set; }
        
       [ForeignKey("Drzava")]
        public int DrzavaID { get; set; }
        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Glumac> Glumci { get; set; }
        public virtual ICollection<Reziser> Reziseri { get; set; }

    }
}
