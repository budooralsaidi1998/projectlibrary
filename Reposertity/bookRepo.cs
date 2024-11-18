using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systemlibrary.models;

namespace Systemlibrary.Reposertity
{
    public class bookRepo
    {
        private readonly ApplicationContext _context;
        public bookRepo(ApplicationContext context)
        {

            _context = context;

        }

        public IEnumerable<book> GetAll()
        {
            return _context.Books.ToList();
        }

        public book GetByName(string name)
        {
            return _context.Books.Find(name);
        }

        public book GetByID(int ID)
        {
            return _context.Books.Find(ID);
        }

        public void Add(book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }


        //public void Update( string name)
        //{
        //    var book = GetByName(name);

        //    if (book!=null)
        //    {
        //        _context.Books.Update(book);
        //        _context.SaveChanges();
        //    }
        //}
        public void Update(int id, string name, string author)
        {
            var book = GetByID(id);

            if (book != null)
            {
                book.namebook = name;
                book.author = author;
             
                _context.Books.Update(book);
                _context.SaveChanges();
            }
        }

        public void Delete( int id)
        {
            var book = GetByID(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

        }

        public double GetTotalPrice()
        {
            return _context.Books.Sum(b=>b.price_book);
        }
        public double GgetMaxPrice()
        {
            return _context.Books.Max(b => b.price_book);
        }

        public int getTotalBorrowedBooks()
        {
            return _context.Books.Sum(b => b.borrowcopies);
        }

        public int getTotalBooksPerCategoryName(string name )
           {
            return _context.Books.Include(b => b.category).Where(b => b.category.cat_name == name).Count();
        }
    }
}
