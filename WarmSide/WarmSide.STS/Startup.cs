using Owin;
using System.Web.Routing;


namespace WarmSide.STS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AuthConfig.Configuration(app);
            UnityConfig.Initialize();
        }
    }
}