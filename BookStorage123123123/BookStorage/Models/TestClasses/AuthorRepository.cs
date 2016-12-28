using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStorage.Models
{
    public class AuthorRepository : IRepository<Author>
    {
        private BookContext db;
        public AuthorRepository(BookContext context)
        {
            this.db = context;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
        }
    }
}