using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Models
{
    public class Sjediste
    {
        public int SjedisteID { get; set; }

        [ForeignKey("Dvorana")]
        public int DvoranaID { get; set; }
        public string Red { get; set; }

        public int Kolona { get; set; }


        //[ForeignKey("SeatType")]
        //public int SeatTypeID { get; set; }

        //public virtual SeatType SeatType { get; set; }

        //public virtual ICollection<ProjectionSeat> ProjectionSeats { get; set; }

        //public virtual ICollection<Ticket> Tickets { get; set; }

        //public bool IsDeleted { get; set; }
    }
}
