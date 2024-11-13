using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systemlibrary.models
{
    public class book
    {
        [Key]
        public int bookid { get; set; }

        [Required]
        public string namebook { get; set; }

        [Required]
        public int borrowcopies { get; set; }

        [Required]
        public string author { get; set; }

        [Required]
        public int copies_number { get; set; }

        [Required]
        public double price_book { get; set; }

        [ForeignKey("category")]

        public int categoryid { get; set; }
        public virtual category category { get; set; }


        public virtual ICollection<borrowing> borrows { get; set; }
    }
}
