using Kino.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class KupacNagradnaIgraDodajVM
    {
        public NagradnaIgraKupac KupacNagradnaIgra { get; set; }
        public List<SelectListItem> Nagradnaigra { get; set; }
        public int NagradnaIgraId { get; set; }
        public List<SelectListItem> Kupac { get; set; }
        public int KupacId { get; set; }
    }
}
