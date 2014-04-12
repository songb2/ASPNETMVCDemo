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

        public PartialViewResult GetPeopleData(string selectedRole="All")
        {
            return PartialView(GetData(selectedRole));
        }

        private IEnumerable<Person> GetData(string selectedRole)
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }

            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            // prepare the data passed to Json method
            // get JSON data we wanted and expressed in a way that is more useful
            // eg. {"FirstName":"Adam","LastName":"Freeman","Role":"Admin"}
            var data = GetData(selectedRole).Select(p => new { 
                FirstName = p.FirstName,
                LastName = p.LastName,
                Role = Enum.GetName(typeof(Role), p.Role)
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeople(string selected = "All")
        {
            return View((object)selected);
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