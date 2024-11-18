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

        //public category GetByName(string name)
        //{
        //    return _context.categories.Find(name);
        //}
        public category GetByName(string name)
        {
            return _context.categories.FirstOrDefault(c => c.cat_name==name);
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


        //public void Update(string name)
        //{
        //    var book = GetByName(name);

        //    if (book != null)
        //    {
        //        _context.categories.Update(book);
        //        _context.SaveChanges();
        //    }
        //}
        public void Update(int id, string newCatName, int newCategoryNumber)
        {
            var categoryToUpdate = GetByID(id);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.cat_name = newCatName;
                categoryToUpdate.number_categery = newCategoryNumber;

                _context.categories.Update(categoryToUpdate);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Category not found.");
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
