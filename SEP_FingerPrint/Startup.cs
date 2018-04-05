using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEP_FingerPrint.Startup))]
namespace SEP_FingerPrint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
