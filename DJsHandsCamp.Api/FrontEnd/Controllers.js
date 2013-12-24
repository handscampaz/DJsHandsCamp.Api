var handsCampControllers = angular.module('handsCampControllers', []);

handsCampControllers.controller('hmHomeCtrl', function ($scope) {
    $scope.title = 'DJs Hands Camp';
    $scope.homeImage = "../DJWRCamp_Images/homeImage.png";
});

handsCampControllers.controller('hcAboutCtrl', function($scope) {
    $scope.title = "About DJ Hackett";
    $scope.aboutImage = "../DJWRCamp_Images/hackett_cowboys.jpg";
});


handsCampControllers.controller('hcRegisterCtrl', function ($scope) {
    $scope.title = 'Please register to become a member.';
});