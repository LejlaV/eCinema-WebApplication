using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class IzaberiKupcaVM
    {
        public List<SelectListItem> Kupac { get; set; }
        public string BrojTelefona { get; set; }
    }
}
