using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarmSide.WebFace.App_Start
{
    public static class AuthConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Auth/LoginViaGoogle")
            };

            app.UseCookieAuthentication(cookieOptions);

            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "1012707702411-c7jj5uh2fge06bfb3hhfbb8t5ud08007.apps.googleusercontent.com",
                ClientSecret = "7z5b4_eErt-77VXpvVq3reZg"
            });
        }
    }
}