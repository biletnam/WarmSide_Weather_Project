using Microsoft.Practices.Unity;
using CityWeatherService.Interfaces;
using CityWeatherService.Services;
using Unity.WebApi;

namespace WarmSide.WebApi
{
    static class Config
    {
        static Config()
        {
            UnityContainer = new UnityContainer();
          
        }

        public static IUnityContainer UnityContainer
        {
            get;
        }

        public static void Initialize()
        {
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(UnityContainer);
            UnityContainer.RegisterType<IFlickerApiPhotoServiceConfig, CityWeatherServiceConfiguration>(new ContainerControlledLifetimeManager());
            UnityContainer.RegisterType<IOpenWeatherApiServiceConfig, CityWeatherServiceConfiguration>(new ContainerControlledLifetimeManager());
            UnityContainer.RegisterType<ICacheServiceConfig, CityWeatherServiceConfiguration>(new ContainerControlledLifetimeManager());
            UnityContainer.RegisterType<IWeatherService, OpenWeatherApiWeatherService>();
            UnityContainer.RegisterType<ICacheService, CacheService>();
            UnityContainer.RegisterType<IUserService, UserService>();
            UnityContainer.RegisterType<IHttpClientFactory, HttpClientFactory>();
            UnityContainer.RegisterType<IWeatherResponseFormatter, WeatherResponseFormatter>();
            UnityContainer.RegisterType<IPhotoService, FlickerApiPhotoService>();
            UnityContainer.RegisterType<ICacheRepository, CacheRepository>();
            UnityContainer.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
