using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class FilmReziser
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
        public int ReziserID { get; set; }
        public virtual Reziser Reziser { get; set; }
    }
}
