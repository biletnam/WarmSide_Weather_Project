(function (angular) {

    angular.module("weatherApp", []);

    angular.module("weatherApp").constant("serverConfig", {
        "serverUrl": "http://warmsidewebapi.azurewebsites.net:80",
        "weatherIconBaseUri": "http://openweathermap.org/img/w/"
    })

})(angular);
