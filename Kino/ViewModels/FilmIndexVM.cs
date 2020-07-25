using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class FilmIndexVM
    {
        public int Id { get; internal set; }
        public string Naziv { get; internal set; }
        public string Sinopsis { get; internal set; }
        public int Trajanje { get; internal set; }
        public string Dobno { get; internal set; }
        public int Godina { get; internal set; }
        public bool Aktivan { get; internal set; }
        public List<string> Zanrovi { get; set; }
        public List<string> Reziseri { get; set; }
        public List<string> Glumci { get; set; }
        public string putanjaSlike { get; set; }
        public string Trailer { get; set; }
        //public float? Ocjena { get; set; }
        //public float? ProsjecnaOcjena { get; set; }

    }
}
