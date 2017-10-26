(function (angular) {
    angular.module('weatherApp').controller('WeatherController', WeatherController);

    WeatherController.$inject = ['$scope', '$http', 'weatherAppDataService', '$filter', 'serverConfig'];

    function WeatherController($scope, $http, weatherAppDataService, $filter, serverConfig) {
        var vm = this;
        vm.serverUrl = serverConfig.serverUrl + '/';
        vm.currentWeatherState = {};
        vm.weatherForecast = {};
        vm.iconUri = '';
        vm.iconBaseUri = serverConfig.weatherIconBaseUri;
        vm.currentCity;
        vm.forecastDays = [];
        vm.dayWeatherForecast = [];
        vm.cityPhotoApiUri = serverConfig.serverUrl + '/';
        vm.cityImageUri = '';

        vm.getCurrentWeather = function(city)
        {
            weatherAppDataService.getCurrentWeather(city).then(function (response) {
                vm.currentWeatherState = response.data;
                vm.iconUri = serverConfig.weatherIconBaseUri + response.data.weather[0].icon + '.png';
            });
        }

        vm.getWeatherForecast = function (city) {
            weatherAppDataService.getForecast(city).then(function (response) {
                vm.weatherForecast = response.data;

                vm.forecastDays = [];

                for (var i = 0; i < vm.weatherForecast.list.length; i++)
                {
                    var day = $filter('date')(vm.weatherForecast.list[i].dt * 1000, 'EEEE');

                    if (!vm.forecastDays.includes(day))
                    {
                        vm.forecastDays.push(day);
                    }
                }

                vm.populateDayForecast(vm.forecastDays[0]);
                vm.cityImageUri = vm.cityPhotoApiUri + vm.currentCity + '/picture';
                document.getElementById("backgroundImage").style.backgroundImage = "url('" + vm.cityImageUri + "')";
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

        vm.populateDayForecast = function (chosenDay) {
            vm.dayWeatherForecast = [];

            for (var i = 0; i < vm.weatherForecast.list.length; i++) {

                var day = $filter('date')(vm.weatherForecast.list[i].dt * 1000, 'EEEE');

                if (day == chosenDay) {
                    vm.dayWeatherForecast.push(vm.weatherForecast.list[i]);
                }
            }
        }

        vm.refreshWeather = function() {
            vm.getCurrentWeather(vm.currentCity);
            vm.getWeatherForecast(vm.currentCity);
        }
    }
})(angular);