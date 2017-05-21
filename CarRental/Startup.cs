using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRental.Startup))]
namespace CarRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
