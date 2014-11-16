using HelenaGerber_Promo.Models.HGStore;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelenaGerber_Promo.Startup))]
namespace HelenaGerber_Promo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
