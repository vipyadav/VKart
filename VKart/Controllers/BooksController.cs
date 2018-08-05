using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VKart.Models;

namespace VKart.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books/Random
        public ActionResult Random()
        {
            var book = new Book
            {
                Name = "The White Tiger!"
            };

            return View(book);
        }
    }
}