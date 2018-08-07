using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VKart.Models;
using System.Data.Entity;


namespace VKart.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _DbContext;

        public CustomersController()
        {
            _DbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _DbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _DbContext.Customers.Include(x => x.MembershipType).ToList(); //EF will not query to DB here. It will execute when we iterate it in View

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _DbContext.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}