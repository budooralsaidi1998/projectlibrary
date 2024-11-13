using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systemlibrary.models
{
    public enum GenderType
    {
        Male,
        Female
    }
    public class user
    {
        [Key]
        public int userid { get; set; }
        [Required]
        public string userName { get; set; }

        [Required]
        public string userEmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public GenderType RGender { get; set; }


        public virtual ICollection<borrowing> Borrowings { get; set; }


    }
}
