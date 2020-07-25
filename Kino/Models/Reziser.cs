using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Reziser
    {
        public int ReziserID { get; set; }

        //[RegularExpression(pattern: "[A-z][a-z]")]
        public string Ime { get; set; }
        //[RegularExpression(pattern: "[A-z][a-z]")]
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string CV { get; set; }
        [ForeignKey("Grad")]
        public int GradID { get; set; }
        public virtual Grad Grad { get; set; }
    }
}
