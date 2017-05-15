(function(angular) {
    angular.module('weatherApp').directive('backImg', BackgroundImageDirective);
    function BackgroundImageDirective() {
        return function (scope, element, attrs) {
            var url = "url('" + attrs.backImg + "')";
                element.css({
                    'background-image':  url,
                })
        }}})(angular);