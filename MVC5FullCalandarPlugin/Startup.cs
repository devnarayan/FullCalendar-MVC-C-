using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5FullCalandarPlugin.Startup))]
namespace MVC5FullCalandarPlugin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
