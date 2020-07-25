using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    public class LoginVM
    {
        [StringLength(20, ErrorMessage="Korisnicko ime mora sadrzavati minimalno 3 karaktera.", MinimumLength =3)]
        public string Username { get; set; }
        [StringLength(20,ErrorMessage ="Password mora sadržavati minimalnio 4 karaktera.", MinimumLength =4)]
        [DataType(DataType.Password)]
         public string Password { get; set; }
        public bool ZapamtiPassword { get; set; }
    }
}
