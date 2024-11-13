using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systemlibrary.models;

namespace Systemlibrary.Reposertity
{
    public class borrowRepo
    {
        private readonly ApplicationContext _context;
        public borrowRepo(ApplicationContext context)
        {

            _context = context;

        }

        public IEnumerable<borrowing> GetAll()
        {
            return _context.borrowings.ToList();
        }

        public borrowing GetByName(string name)
        {
            return _context.borrowings.Find(name);
        }

        public borrowing GetByID(int ID)
        {
            return _context.borrowings.Find(ID);
        }

        public void Add(borrowing book)
        {
            _context.borrowings.Add(book);
            _context.SaveChanges();
        }


        public void Update(string name)
        {
            var book = GetByName(name);

            if (book != null)
            {
                _context.borrowings.Update(book);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var book = GetByID(id);
            if (book != null)
            {
                _context.borrowings.Remove(book);
                _context.SaveChanges();
            }

        }

      
}
}
