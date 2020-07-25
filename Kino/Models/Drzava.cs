using System.ComponentModel.DataAnnotations;

namespace Kino.Models
{
    public class Drzava
    {
        [Key]
        public int DrzavaID { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

    }
}
