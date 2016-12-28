using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStorage.Models
{
    public class BookRepository : IRepository<Book>
    {
        private BookContext db;
        public BookRepository(BookContext context)
        {
            this.db = context;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }
    }
}