using Kino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class FilmKupacVM
    {
            public List<Projekcija> projekcije { get; set; }
            public int Ocjena { get; set; }
            public int Id { get; set; }
            public string Sinopsis { get; set; }
            public string Naziv { get; set; }
            public string PutanjaSlike { get; set; }
            public int Trajanje { get; internal set; }
            public string Dobno { get; internal set; }
            public int Godina { get; internal set; }
            public List<string> Zanrovi { get; set; }
            public List<string> Reziseri { get; set; }
            public List<string> Glumci { get; set; }
            public string Trailer { get; set; }
          public float? ProsjecnaOcjena { get; set; }
        public class Projekcija
        {
            public int ProjekcijaId { get; set; }
            public DateTime DatumPočetka { get; set; }
            public string Dvorana { get; set; }
            public double Cijena {get;set;}
        }
    }
}