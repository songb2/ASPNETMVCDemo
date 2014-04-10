using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(URLAndAjaxHelperDemo.Startup))]
namespace URLAndAjaxHelperDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
