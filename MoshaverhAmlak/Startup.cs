using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoshaverhAmlak.Startup))]
namespace MoshaverhAmlak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
