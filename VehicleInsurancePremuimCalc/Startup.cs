using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleInsurancePremuimCalc.Startup))]
namespace VehicleInsurancePremuimCalc
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
