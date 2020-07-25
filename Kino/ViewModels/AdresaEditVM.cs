using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class AdresaEditVM
    {
        public int AdresaID { get; set; }
        public string NazivUlice { get; set; }

        public List<SelectListItem> Grad { get; set; }
        public int GradId { get; set; }


    }
}
