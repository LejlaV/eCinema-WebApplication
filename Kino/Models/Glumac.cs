using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Glumac
    {
        public int GlumacID{ get; set; }
       
        //[RegularExpression(pattern: "[A-z][a-z]")]
        public string Ime { get; set; }
        //[RegularExpression(pattern: "[A-z][a-z]")]
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        //potrebno dropat bazu pa preimenovati
        public string CV { get; set; }
        [ForeignKey("Grad")]
        public int GradID { get; set; }
        public virtual Grad Grad { get; set; }
    }
}
