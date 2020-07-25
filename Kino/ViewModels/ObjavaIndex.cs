using Kino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class ObjavaIndex
    {
        public int ObjavaID { get; set; }
        public int KorisnikID { get; set; }
        public string ImePrez { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumObjave { get; set; }
        public List<Komentar> komentari { get; set; }
        public string Slika { get; set; }
    }
}
