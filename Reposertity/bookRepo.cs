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
            return _context.Books.FirstOrDefault(c => c.namebook == name);
        }
        public book GetByID(int ID)
        {
            return _context.Books.Find(ID);
        }

        //public void Add(book book)
        //{
        //    _context.Books.Add(book);
        //    _context.SaveChanges();
        //}
        public void Add(book book)
        {
            // Ensure category is valid and exists in the database
            var category = _context.categories.FirstOrDefault(c => c.CId == book.categoryid);
            if (category == null)
            {
                Console.WriteLine("Category does not exist.");
            }

            // Add the book with the related category
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
        //public void Update(int bookid, string namebook,string author, int borrowcopies)
        //{
        //    var book = GetByID(bookid);

        //    if (book != null)
        //    {
        //        book.namebook = namebook;
        //        book.author = author;
        //        book.borrowcopies = borrowcopies;

        //        _context.Books.Update(book);
        //        _context.SaveChanges();
        //    }
        //}

        public void Update(int bookid, string namebook, string author, int borrowcopies)
        {
            var book = _context.Books.Find(bookid);

            if (book != null)
            {
                book.namebook = namebook;
                book.author = author;
                book.borrowcopies = borrowcopies;

                _context.Books.Update(book); // This line is redundant with tracked entities, but safe
                _context.SaveChanges();      // Ensure SaveChanges is called here
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

        //public int getTotalBooksPerCategoryName(string name )
        //   {
        //    return _context.Books.Include(b => b.category).Where(b => b.category.cat_name == name).Count();
        //}
        public int getTotalBooksPerCategoryName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be null or empty.");
            }

            return _context.Books
                .Include(b => b.category) // Ensure the category is loaded
                .Where(b => b.category != null && b.category.cat_name == name)
                .Count();
        }

    }
}
