using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systemlibrary.models
{
    public class adming
    {
        [Key]
        public int adminid { get; set; }
        [Required]
        public string admin_name { get; set; }

        [Required]
        public string admin_email { get; set; }

        [Required]
        public int admin_password { get; set; }



    }
}
