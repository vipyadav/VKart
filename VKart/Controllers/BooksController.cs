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

            //return View(book);

            //return Content("Hello World!");

            //return HttpNotFound();

            // return new EmptyResult();

            // return RedirectToAction("Index","Home", new { page = 1, sortBy ="Id"});

            // return Json(new { Name = "Vipin Yadav", ID = 9, DateOfBirth = new DateTime(1989, 11, 08) }, JsonRequestBehavior.AllowGet);


            // To Download File
            //return File(Url.Content("~/Assets/Files/testFile.txt"), "text/plain", "testFile.txt");

            // To Display content on Browser
            //byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Assets/Files/testFile.txt"));
            //return File(fileBytes, "text/plain");

            return Redirect("http://vipinkumaryadav.com/");
        }
    }
}