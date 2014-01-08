var handsCampApp = angular.module('handsCampApp', ['ngRoute', 'ngResource', 'handsCampControllers']);

handsCampApp.config(function($routeProvider) {
    $routeProvider.
        when('/', {
            templateUrl: 'FrontEnd/Home/hcHome.html',
            controller: 'hmHomeCtrl'
        }).
        when('/about', {
            templateUrl: 'FrontEnd/About/hcAbout.html',
            controller: 'hcAboutCtrl'                
        }).
        when('/register', {
            templateUrl: 'FrontEnd/Login/hcContactForm.html',
            controller: 'hcRegisterCtrl'
        }).
        otherwise({
            redirectTo: '/'
        });

});