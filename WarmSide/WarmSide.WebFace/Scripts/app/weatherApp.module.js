(function (angular) {

    angular.module("weatherApp", []);

    angular.module("weatherApp").constant("serverConfig", {
        "serverUrl": "http://ec2-34-209-154-143.us-west-2.compute.amazonaws.com",
        "port": "83"
    })

})(angular);
