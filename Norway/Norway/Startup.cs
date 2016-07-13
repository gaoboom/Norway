using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Norway.Startup))]
namespace Norway
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
