using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HINAdventures.Startup))]
namespace HINAdventures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
