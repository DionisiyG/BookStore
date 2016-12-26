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
            try
            {
                if (ModelState.IsValid)
                {
                    dbBooks.Books.Add(book);
                    dbBooks.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book bookEdit = dbBooks.Books.Include(a => a.Author).Where(a => a.AuthorId == id).Single();
            return View(bookEdit);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    dbBooks.Entry(book).State = EntityState.Modified;
                  
                    dbBooks.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
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
                //Log the error (add a variable name after DataException) 
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {
                { "id", id },
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
