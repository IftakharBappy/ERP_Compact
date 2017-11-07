using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERP_Compact.Startup))]
namespace ERP_Compact
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
