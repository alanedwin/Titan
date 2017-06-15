using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(titan.Startup))]
namespace titan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
