using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class KupacIndex
    {        public string Ime { get; set; }
            public string Prezime { get; set; }
            public string BrojTelefona { get; set; }
            public DateTime Datum { get; set; }
            public string NazivGrada { get; set; }
            public int KorisnikId { get; set; }
            public int KupacId { get; set; }
            public string Slika { get; set; }
        }
}
