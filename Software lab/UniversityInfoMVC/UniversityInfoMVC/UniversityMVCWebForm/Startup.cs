using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityMVCWebForm.Startup))]
namespace UniversityMVCWebForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
