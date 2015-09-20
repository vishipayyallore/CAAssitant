using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CAAssistant.Startup))]
namespace CAAssistant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
