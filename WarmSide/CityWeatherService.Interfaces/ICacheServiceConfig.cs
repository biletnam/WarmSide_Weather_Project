﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface ICacheServiceConfig
    {
        TimeSpan CacheLifetimeInHours { get; }
    }
}
