using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEOTest.Startup))]
namespace SEOTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
