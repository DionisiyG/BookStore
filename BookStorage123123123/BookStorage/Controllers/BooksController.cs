using BookStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;

namespace BookStorage.Controllers
{
    public class BooksController : Controller
    {
        BookContext dbBooks = new BookContext();

        // GET: Books
        public ActionResult Index()
        {

            var books = dbBooks.Books.Include(a => a.Author);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book bookDetails = dbBooks.Books.Include(a => a.Author).Where(a => a.AuthorId == id).Single();

            return View(bookDetails);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            Book books = new Book();
            return View(books);
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);

            }
            dbBooks.Books.Add(book);
            dbBooks.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Books/Edit/5       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //var compModel = new BookAuthorCompositeModel();

            Book bookEdit = dbBooks.Books.ToList().Where(a => a.Id == id).SingleOrDefault();
            var list = dbBooks.Books.Select(x => new { ID = x.Id, AuthorName = x.Author.AuthorName });
            ViewBag.Authors = new SelectList(list, "Id", "AuthorName");
            return View(bookEdit);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                dbBooks.Entry(book).State = EntityState.Modified;
                dbBooks.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        [HandleError()]
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            return View(dbBooks.Books.Include(a => a.Author).Where(a => a.AuthorId == id).Single());
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Book book = dbBooks.Books.Find(id);
                dbBooks.Books.Remove(book);
                dbBooks.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {
                { "id", id },
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
