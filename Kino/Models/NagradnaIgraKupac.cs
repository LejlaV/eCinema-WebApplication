using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class NagradnaIgraKupac
    {
        public int NagradnaIgraKupacId{ get; set; }

        public Kupac Kupac { get; set; }
        public int KupacId { get; set; }
        public NagradnaIgra NagradnaIgra { get; set; }
        public int NagradnaIgraId { get; set; }
      
    }
}
