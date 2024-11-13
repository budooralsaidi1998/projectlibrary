using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systemlibrary.models;

namespace Systemlibrary.Reposertity
{
    public class userRepo
    {
        private readonly ApplicationContext _context;
        public userRepo(ApplicationContext context)
        {

            _context = context;

        }

        public IEnumerable<user> GetAll()
        {
            return _context.Users.ToList();
        }

        public user GetByName(string name)
        {
            return _context.Users.Find(name);
        }

        public user GetByID(int ID)
        {
            return _context.Users.Find(ID);
        }

        public void Add(user book)
        {
            _context.Users.Add(book);
            _context.SaveChanges();
        }


        public void Update(string name)
        {
            var book = GetByName(name);

            if (book != null)
            {
                _context.Users.Update(book);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var book = GetByID(id);
            if (book != null)
            {
                _context.Users.Remove(book);
                _context.SaveChanges();
            }

        }

        public int countByGender(GenderType gender)
        {
            return _context.Users.Count(s=>s.RGender==gender);

        }
           

        }
    }


