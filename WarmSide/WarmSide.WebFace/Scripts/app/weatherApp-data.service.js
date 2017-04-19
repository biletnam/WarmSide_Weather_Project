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
                url: serverUrl + 'api/Weather/GetCurrentWeather?city=' + city,
                method: "GET",
            });

            return promise;
        }

        function getForecast(city) {
            var promise = $http({
                url: serverUrl + 'api/Weather/GetForecast?city=' + city,
                method: "GET",
            });

            return promise;
        }
    }
})(angular);