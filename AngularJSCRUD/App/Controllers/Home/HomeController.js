angular.module('myFormApp')
    .controller('homeController', function ($scope, $http, $location, $window, homeService) {

        $scope.message = 'Hello World';

        homeService
            .getTiles()
            .success(function (result) {
                $scope.tiles = result;
            })
            .error(function () {
                
            });

    });