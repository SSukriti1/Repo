using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCcrud.Startup))]
namespace MVCcrud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
