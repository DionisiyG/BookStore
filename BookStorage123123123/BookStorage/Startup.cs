using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStorage.Startup))]
namespace BookStorage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
