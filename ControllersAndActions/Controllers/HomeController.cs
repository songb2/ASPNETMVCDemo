using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Message = "Your index page.";
            ViewBag.RequestUrl = Request.Url;
            ViewBag.UserHostAddress = Request.UserHostAddress;
            ViewBag.serverName = Server.MachineName;
            string userName = User.Identity.Name;
           

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

        public RedirectResult RedirectToAbout()
        {
            return Redirect("/Home/About");
            //return RedirectPermanent("/Home/About");
        }

        public RedirectToRouteResult RedirectToRouteResult()
        {
            return RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyID" });
        }
    }
}