using BasicMVCNorthwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicMVCNorthwind.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Fruits = new string[] { "Apple", "Orange", "Pear" };
            ViewBag.Cities = new string[] { "New York", "London", "Paris" };

            string message = "This is an HTML element: <input>";

            return View((object)message);
        }

        public ActionResult CreateCustomer()
        {
            return View(new Customers());
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customers customer)
        {
            return View(customer);
        }

        public ActionResult CreateEmployee()
        {
            return View(new Employees());
        }
    }
}
