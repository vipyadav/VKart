﻿
using System.Collections.Generic;
using System.Web.Mvc;
using VKart.Models;
using VKart.ViewModels;

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

            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                 new Customer{Name = "Customer 2"},
            };

            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Customers = customers
            };

            return View(viewModel);

            //ViewData["Book"] = book;

            //ViewBag.Book = book;

            //return View();

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

            //return Redirect("http://vipinkumaryadav.com/");
        }

        public ActionResult Edit(int bookId)
        {
            return Content($"Id = {bookId}");
        }

        //Books
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content($"PageIndex = {pageIndex}, sortBy = {sortBy}");
        }

        public ActionResult ByReleaseDate(int year, byte month)
        {

            return Content($"{year}/{month}");
        }

        [Route("books/authors/{author:minlength(3)}")]
        public ActionResult ByAuthors(string author)
        {

            return Content($"Author Name = {author}");
        }

       
    }
}