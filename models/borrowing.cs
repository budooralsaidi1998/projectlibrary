using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Systemlibrary.models
{
    [PrimaryKey(nameof(userid),nameof(bookid),nameof(borrow_date))]
    public class borrowing
    {
        [Required]
        public DateTime borrow_date { get; set; }

        public DateTime return_date { get; set; }

        public DateTime actual_date { get; set; }

        public int rating { get; set; }

        public bool isreturn { get; set; }

        [ForeignKey("user")]
        public int userid { get; set; }
        public virtual user user { get; set; }

        [ForeignKey("books")]
        public int bookid { get; set; }
        public virtual book books { get; set; }


    }
}
