using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Trajanje { get; set; }
        public string DobnoOgraničenje { get; set; }
        public int GodinaIzdavanja { get; set; }
        public string Sinopsis { get; set; }
        public bool Aktuelan { get; set; }
        //uraditi?!
        public string Slika { get; set; }
        public string Trailer { get; set; }
        public double Zarada { get; set; }


        //public virtual ICollection<MovieRole> MovieRoles { get; set; }

        //public virtual ICollection<MovieDirection> MovieDirections { get; set; }


        //public virtual ICollection<Projection> Projections { get; set; }

        //public bool IsDeleted { get; set; }
    }
}
