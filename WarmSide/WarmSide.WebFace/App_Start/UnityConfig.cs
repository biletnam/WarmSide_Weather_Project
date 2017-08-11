using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;
using WarmSide.WebFace.Interfaces;

namespace WarmSide.WebFace.App_Start
{
    static class UnityConfig
    {
        static UnityConfig()
        {
            UnityContainer = new UnityContainer();
        }

        public static IUnityContainer UnityContainer
        {
            get;
        }


        public static void Initialize()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityContainer));
            UnityContainer.RegisterType<IUserManagerConfiguration, UserManagerConfiguration>(new ContainerControlledLifetimeManager());
            UnityContainer.RegisterType<IUserManager, UserManager>();
            UnityContainer.RegisterType<IHttpClientFactory, HttpClientFactory>();
            
        }
    }
}