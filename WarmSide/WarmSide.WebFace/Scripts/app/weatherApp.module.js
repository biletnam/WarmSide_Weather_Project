(function (angular) {

    angular.module("weatherApp", []);

    angular.module("weatherApp").constant("serverConfig", {
        "serverUrl1": "http://localhost:50798",
        "serverUrl": "http://warmsidewebapi.azurewebsites.net",
        "weatherIconBaseUri": "http://openweathermap.org/img/w/"
    })

})(angular);
