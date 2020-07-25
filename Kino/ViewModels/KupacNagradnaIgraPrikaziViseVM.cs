using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class KupacNagradnaIgraPrikaziViseVM
    {
        public int NagradnaId { get; set; }
        public string Sadrzaj { get; set; }
        public string Naziv { get; set; }
        public DateTime Početak { get; set; }
        public DateTime Kraj { get; set; }
    }
}
