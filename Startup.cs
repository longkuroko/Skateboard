using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkateBoard.Startup))]
namespace SkateBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
