using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VKart.Models;
using System.Data.Entity;
using VKart.ViewModels;

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

        public ActionResult New()
        {
            var membershiptypes = _DbContext.MembershipTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                MembershipTypes = membershiptypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveOrUpdate(CustomerViewModel customerViewModel)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customerViewModel.Customer,
                    MembershipTypes = _DbContext.MembershipTypes.ToList()
                };

                return View("New",viewModel);
            }

            if (customerViewModel.Customer.Id == 0)
                _DbContext.Customers.Add(customerViewModel.Customer);
            else
            {
                var customerInDb = _DbContext.Customers.SingleOrDefault(x => x.Id == customerViewModel.Customer.Id);

                customerInDb.Name = customerViewModel.Customer.Name;
                customerInDb.MemberShipTypeId = customerViewModel.Customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = customerViewModel.Customer.IsSubscribedToNewsletter;

            }
            _DbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _DbContext.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _DbContext.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }
    }
}