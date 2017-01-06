using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestLabMVC.Startup))]
namespace TestLabMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
