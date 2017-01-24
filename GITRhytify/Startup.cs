using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GITRhytify.Startup))]
namespace GITRhytify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
