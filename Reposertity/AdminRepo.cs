using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systemlibrary.models;

namespace Systemlibrary.Reposertity
{
    public class AdminRepo
    {
        private readonly ApplicationContext _context;
        public AdminRepo(ApplicationContext context)
        {

            _context = context;

        }
        public void Add(adming book)
        {
            _context.admings.Add(book);
            _context.SaveChanges();
        }

        public adming GetByName(string name)
        {
            return _context.admings.Find(name);
        }

        public List<adming> GetAllAdmin()
        {
            return _context.admings.ToList();
        }

        public void Update(string name)
        {
            var book = GetByName(name);

            if (book != null)
            {
                _context.admings.Update(book);
                _context.SaveChanges();
            }
        }
        public adming GetByID(int ID)
        {
            return _context.admings.Find(ID);
        }


        public void Delete(int id)
        {
            var book = GetByID(id);
            if (book != null)
            {
                _context.admings.Remove(book);
                _context.SaveChanges();
            }

        }
    }
}
