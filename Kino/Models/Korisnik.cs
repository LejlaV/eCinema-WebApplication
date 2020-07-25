using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Guid AutorizacijskiToken { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Slika { get; set; }
        public DateTime DatumRodjenja { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        [ForeignKey(nameof(Grad))]
        public int? GradID { get; set; }
        public Grad Grad { get; set; }

        [ForeignKey(nameof(Uloga))]
        public int UlogaID { get; set; }
        public Uloga Uloga { get; set; } //Admin, Uposlenik, Kupac
    }
}
