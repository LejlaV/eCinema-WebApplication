using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class ObjavaAddVM
    {
        public int ObjavaID { get; set; }
        public int UposlenikID { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumObjave { get; set; }
        public string putanjaSlike { get; set; }
        public IFormFile Slika { get; set; }
    }
}
