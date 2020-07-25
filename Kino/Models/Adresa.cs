using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Adresa
    {  [Key]
        public int AdresaID { get; set; }
        public string NazivUlice { get; set; }
       
        [ForeignKey("Grad")]
        public int GradId { get; set; }

        public Grad Grad { get; set; }

    }
}
