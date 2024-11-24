using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systemlibrary.models;

namespace Systemlibrary
{
    public class ApplicationContext:DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(" Data Source=localhost; Initial Catalog=library; Integrated Security=true; TrustServerCertificate=True ");
        }

        public DbSet<book> Books { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<borrowing> borrowings { get; set; }
        public DbSet<adming> admings { get; set; }
        public DbSet<category> categories { get; set; }

    }

}
