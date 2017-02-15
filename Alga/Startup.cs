using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alga.Startup))]
namespace Alga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
