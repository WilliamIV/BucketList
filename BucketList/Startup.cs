using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BucketList.Startup))]
namespace BucketList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
