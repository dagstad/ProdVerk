using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PresseLogg.Startup))]
namespace PresseLogg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
