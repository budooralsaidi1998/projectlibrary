using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systemlibrary.models
{
    public class category
    {
        [Key]
        public int CId { get; set; }
        [Required]
        public string cat_name { get; set; }
        [Required]
        public int number_categery { get; set; }

        public virtual ICollection<book> Books { get; set; }
    }
}
