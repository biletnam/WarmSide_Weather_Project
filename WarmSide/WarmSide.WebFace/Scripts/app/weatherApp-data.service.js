(function (angular) {

    angular
        .module("weatherApp")
        .factory("weatherAppDataService", webAudioDataService);

    webAudioDataService.$inject = ["$http", "serverConfig"];

    function webAudioDataService($http, serverConfig) {

        var serverUrl = serverConfig.serverUrl + ':' + serverConfig.port + '/';

        var service = {
            getCurrentWeather: getCurrentWeather,
            getForecast: getForecast,
        };

        return service;

        function getCurrentWeather(city) {
            var promise = $http({
                url: serverUrl + serverConfig.currentWeatherApiBaseUri + city,
                method: "GET",
            });

            return promise;
        }

        function getForecast(city) {
            var promise = $http({
                url: serverUrl + serverConfig.weatherForecastApiBaseUri + city,
                method: "GET",
            });

            return promise;
        }
    }
})(angular);