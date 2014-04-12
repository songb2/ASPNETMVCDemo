using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URLAndAjaxHelperDemo.Models;

namespace URLAndAjaxHelperDemo.Controllers
{
    public class PeopleController : Controller
    {

        private Person[] personData = { 
            new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {FirstName = "Steven", LastName = "Sanderson", Role = Role.Admin},
            new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            // if it's ajax request, then parse to Json data
            if (Request.IsAjaxRequest())
            {
                // prepare the data passed to Json method
                // get JSON data we wanted and expressed in a way that is more useful
                // eg. {"FirstName":"Adam","LastName":"Freeman","Role":"Admin"}
                var formattedData = data.Select(p => new
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = Enum.GetName(typeof(Role), p.Role)
                });
                return Json(formattedData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView(data);
            }
        }


        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole = "All")
        //{
        //    if (selectedRole == null || selectedRole == "All")
        //    {
        //        return View(personData);
        //    }
        //    else
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        return View(personData.Where(p => p.Role == selected));
        //    }
        //}
    }
}