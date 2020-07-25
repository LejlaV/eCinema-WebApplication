using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class RezervacijaIndex
    {
        public int RezervacijaID { get; set; }
        public string Kupac { get; set; }
        public string NazivFilma { get; set; }
        public bool Zakljucena { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime DatumProjekcije { get; set; }

        public int OdabraniBrojSjedista{ get; set; }
        public double UkupnaCijena{ get; set; }
    }
}
