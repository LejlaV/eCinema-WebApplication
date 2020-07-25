using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class AdminVM
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public int UkupanBrojKorisnika { get; set; }
        public double UkupnaZarada { get; set; }
        public string UserName { get; set; }
        public int TrenutnoLokacija{ get; set; }
        public int TrenutnoFilmova { get; set; }
        public int TrenutnoRezervacija { get; set; }

    }
}
