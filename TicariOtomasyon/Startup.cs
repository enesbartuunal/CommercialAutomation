using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicariOtomasyon.Startup))]
namespace TicariOtomasyon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
