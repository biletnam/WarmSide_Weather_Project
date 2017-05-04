(function (angular) {

    angular.module("weatherApp", []);

    angular.module("weatherApp").constant("serverConfig", {
        "serverUrl": "http://localhost",
        "port": "50798",
        "weatherIconBaseUri": "http://openweathermap.org/img/w/",
        "weatherForecastApiBaseUri": "api/Weather/GetForecast?city=",
        "currentWeatherApiBaseUri" : "api/Weather/GetCurrentWeather?city=",
        "cityPictureApiUrl": "api/PlacePhoto/GetCityPhoto?cityName="
    })

})(angular);
