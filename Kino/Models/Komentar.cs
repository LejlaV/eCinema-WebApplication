
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Komentar
    {
        public int KomentarId { get; set; } 
        public Objava Objava { get; set; }
        public int ObjavaId { get; set; }
        public Kupac Kupac { get; set; }
        public int KupacId { get; set; }
        public DateTime Datum { get; set; }
        public string Sadrzaj { get; set; }

        public bool Dodaj(Komentar k){
            MojDbContext db = new MojDbContext();
            db.Komentar.Add(k);
            return db.SaveChanges() > 0;
        }
     
    }
}
