using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Zanr
    {
        [Key]
        public int ZanrID { get; set; }
       // [RegularExpression(pattern: "[A-z][a-z]")]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Zarada { get; set; }
    }
}
