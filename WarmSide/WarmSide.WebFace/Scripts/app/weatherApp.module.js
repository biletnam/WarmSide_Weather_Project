(function (angular) {

    angular.module("weatherApp", []);

    angular.module("weatherApp").constant("serverConfig", {
        "serverUrl": "http://localhost",
        "port": "83"
    })

})(angular);
