using Microsoft.Practices.Unity;
using System.Web.Mvc;
using WarmSide.STS.DAL;
using WarmSide.STS.Interfaces;
using Microsoft.Practices.Unity.Mvc;


namespace WarmSide.STS
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
            UnityContainer.RegisterType<IUserService, UserService>();
            UnityContainer.RegisterType<IUserRepository, UserRepository>();      
        }
    }
}