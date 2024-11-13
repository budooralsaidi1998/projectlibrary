using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systemlibrary.models;

namespace Systemlibrary.Reposertity
{
    public class categoryRepo
    {
        private readonly ApplicationContext _context;
        public categoryRepo(ApplicationContext context)
        {

            _context = context;

        }

        public IEnumerable<category> GetAll()
        {
            return _context.categories.ToList();
        }

        public category GetByName(string name)
        {
            return _context.categories.Find(name);
        }

        public category GetByID(int ID)
        {
            return _context.categories.Find(ID);
        }

        public void Add(category book)
        {
            _context.categories.Add(book);
            _context.SaveChanges();
        }


        public void Update(string name)
        {
            var book = GetByName(name);

            if (book != null)
            {
                _context.categories.Update(book);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var book = GetByID(id);
            if (book != null)
            {
                _context.categories.Remove(book);
                _context.SaveChanges();
            }

        }

    }
}
