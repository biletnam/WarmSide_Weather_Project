(function (angular) {
    angular.module('weatherApp').controller('WeatherController', WeatherController);

    WeatherController.$inject = ['$scope', '$http', 'weatherAppDataService', '$interval', 'serverConfig'];

    function WeatherController($scope, $http, weatherAppDataService, $interval, serverConfig) {
        var vm = this;
        vm.serverUrl = serverConfig.serverUrl + ':' + serverConfig.port + '/';
        vm.currentWeatherState = {};
        vm.weatherForecast = {};
        vm.iconUri = '';
        vm.currentCity = 'Los Angeles';

        vm.getCurrentWeather = function(city)
        {
            weatherAppDataService.getCurrentWeather(city).then(function (response) {
                vm.currentWeatherState = response.data;
                vm.iconUri = 'http://openweathermap.org/img/w/' + response.data.weather[0].icon + '.png';
            });
        }

        vm.getWeatherForecast = function (city) {
            weatherAppDataService.getForecast(city).then(function (response) {
                vm.weatherForecast = response.data;
                console.log(response.data.list.length);
            });
        }

        vm.getCloudinessLevelDesc = function (cloudinessLevel) {
                if (cloudinessLevel < 10)
                    return 'Sky is clear';
                else if (cloudinessLevel < 30)
                    return 'Mostly Clear';
                else if (cloudinessLevel < 50)
                    return 'Partly Cloudy';
                else if (cloudinessLevel < 70)
                    return 'Mostly Cloudy';
                else return 'Cloudy';
            }

        vm.getCurrentWeather(vm.currentCity);
        vm.getWeatherForecast(vm.currentCity);
    }
})(angular);