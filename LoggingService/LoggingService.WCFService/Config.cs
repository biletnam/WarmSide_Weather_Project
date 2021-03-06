﻿using Microsoft.Practices.Unity;
using LoggingService.WCFService.LogServices;

namespace LoggingService.WCFService
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
            UnityContainer.RegisterType<ILoggingProvider, SerilogLoggingProvider>();
            UnityContainer.RegisterType<WCFLogger>();
        }
    }
}
