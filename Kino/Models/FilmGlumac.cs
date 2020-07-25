using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class FilmGlumac
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
        public int GlumacID { get; set; }
        public virtual Glumac Glumac { get; set; }
    }
}
