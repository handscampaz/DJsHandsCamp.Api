var handsCampApp = angular.module('handsCampApp', ['ngRoute', 'handsCampControllers']);

handsCampApp.config(function($routeProvider) {
    $routeProvider.
        when('/', {
            templateUrl: 'Home/hcHome.html',
            controller: 'hmHomeCtrl'
        }).
        when('/about', {
            templateUrl: 'About/hcAbout.html',
            controller: 'hcAboutCtrl'                
        }).
        when('/register', {
            templateUrl: 'Login/hcRegisterForm.html',
            controller: 'hcRegisterCtrl'
        }).
        otherwise({
            redirectTo: '/'
        });

});