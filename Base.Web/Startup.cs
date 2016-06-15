using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Base.Web.Startup))]
namespace Base.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
