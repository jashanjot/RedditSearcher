using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedditSearch.Startup))]
namespace RedditSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
