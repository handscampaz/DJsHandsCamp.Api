var handsCampApp = angular.module('handsCampApp', ['ngRoute', 'handsCampControllers']);

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
            templateUrl: 'FrontEnd/Login/hcRegisterForm.html',
            controller: 'hcRegisterCtrl'
        }).
        otherwise({
            redirectTo: '/'
        });

});