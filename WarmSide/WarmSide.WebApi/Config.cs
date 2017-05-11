using Microsoft.Practices.Unity;
using CityWeatherService.Interfaces;
using CityWeatherService.Services;

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
            var config = new CityWeatherServiceConfiguration();

            UnityContainer.RegisterType<IPhotoService, FlickerApiPhotoService>(new InjectionConstructor(config));
            UnityContainer.RegisterType<IWeatherService, OpenWeatherApiWeatherService>(new InjectionConstructor(config));
        }
    }
}
