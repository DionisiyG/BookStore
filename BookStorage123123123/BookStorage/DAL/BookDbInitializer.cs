using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStorage.Models
{
    
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Authors.Add(new Author { Id = 1, AuthorName = "name1" });
            db.Authors.Add(new Author { Id = 2 , AuthorName = "name2" });
            db.Authors.Add(new Author { Id = 3, AuthorName = "name3" });
            db.Authors.Add(new Author { Id = 4, AuthorName = "name4"});
            

            db.Books.Add(new Book { AuthorId = 1, Title = "NameOfBook1", Price = 1252, YearPublish = 1996 });
            db.Books.Add(new Book { AuthorId = 2,  Title = "NameOfBook2", Price = 2342, YearPublish = 1992 });
            db.Books.Add(new Book { AuthorId = 3, Title = "NameOfBook3", Price = 263, YearPublish = 1991 });
            db.Books.Add(new Book { AuthorId = 4, Title = "NameOfBook4", Price = 23252, YearPublish = 1994});
            
            
            

            base.Seed(db);
        }
    }
}