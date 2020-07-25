using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models.ManyToManyClasses
{
    public class FilmZanr
    {
        public int Id { get; set; }
        // referencijalni integritet + unique da se ne ponavljaju kombinacije
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
        public int ZanrId { get; set; }
        public virtual Zanr Zanr { get; set; }
    }
}
