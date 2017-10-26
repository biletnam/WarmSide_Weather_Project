using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;


namespace WarmSide.STS
{
    public static class AuthConfig
    {
        public static void Configuration(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Auth/Login"),
                AuthenticationType = "Application Cookie",
                CookieDomain = "localhost",
                CookieName = "WarmSideSTS"
            };

            app.UseCookieAuthentication(cookieOptions);

            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);
        }
    }
}