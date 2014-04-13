using MvcModels.Infrastructure;
using MvcModels.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcModels
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //// register factory class which will create the instances of our providers
            //// register at the firstly place to take precedence over the built-in providers
            //ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());

            ModelBinders.Binders.Add(typeof(AddressSummary), new AddressSummaryBinder());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
