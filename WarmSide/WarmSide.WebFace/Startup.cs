using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using WarmSide.WebFace.App_Start;

namespace WarmSide.WebFace
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