using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreFront6.UI.MVC.Startup))]
namespace StoreFront6.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
