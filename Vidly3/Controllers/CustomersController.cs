using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;

namespace Vidly3.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> _customers = new List<Customer>
        {
            new Customer { Name = "Customer 1", Id = 1},
            new Customer { Name = "Customer 2", Id = 2}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomerIndexViewModel() { Customers = _customers };
            return View(viewModel);
        }

        // GET: Customers/Details/Id
        public ActionResult Details(int Id)
        {
            if (!_customers.Any(c => c.Id == Id))
            {
                return HttpNotFound();
            }

            var customer = _customers.FirstOrDefault(c => c.Id == Id);
            return View(customer);
        }
    }
}