using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lesson5.Startup))]
namespace Lesson5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
