using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookStorage.Models;

namespace BookStorage.Controllers
{
    public class HomeController : Controller
    {
        //BookContext db = new BookContext();
        public ActionResult Index()
        {
          //  var books = db.Books.Include(a => a.Author);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}