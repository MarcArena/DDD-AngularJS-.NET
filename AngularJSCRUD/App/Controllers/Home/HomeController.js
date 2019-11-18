angular.module('myFormApp')
    .controller('homeController', function ($scope, $http, $location, $window, homeService, calculationsService, airportsService) {

        $scope.message = 'Hello World';

        homeService
            .getTiles()
            .success(function (result) {
                $scope.tiles = result;
            })
            .error(function () {

            });


        function getAllAirports() {
            airportsService
                .getAirports()
                .success(function (result) {
                    $scope.airports = result;
                    console.log(result);
                })
                .error(function () {

                });
        }

        $scope.airports = [];

        $scope.getAirportsBySearchString = function(searchString) {
            airportsService
                .getAirportsBySearchString(searchString)
                .success(function (result) {
                    $scope.airports.push(result.Airports[0]);
                    //console.log(result);
                    return $scope.airports[0];
                })
                .error(function () {

                });
        }

        //$scope.a1 = $scope.getAirportsBySearchString('PMI');

        //$scope.a2 = $scope.getAirportsBySearchString('MAH');

        // var distance = calculationsService.getDistanceBetweenPoints(a1.Latitude, a1.Longitude, a2.Latitude, a2.Longitude)

        $scope.calculating = true;


        $scope.getDistance = function (airport1, airport2) {

            $scope.calculating = true;

            $scope.a1 = $scope.airports[0];
            $scope.a2 = $scope.airports[1];


            console.log($scope.a1);
            console.log($scope.a2);

            //calculationsService.getDistanceBetweenPointsInKilometers($scope.a1.Latitude, $scope.a1.Longitude, $scope.a2.Latitude, $scope.a2.Longitude).then(function (result) {
            //    $scope.distance = result;
            //    console.log(result);                
            //})


            //calculationsService
            //    .getDistanceBetweenPointsInKilometers($scope.a1.Latitude, $scope.a1.Longitude, $scope.a2.Latitude, $scope.a2.Longitude)
            //    .success(function (result) {
            //        $scope.distance = result;
            //        console.log(result);       
            //    })
            //    .error(function () {

            //    });

            $scope.distance = calculationsService.getDistanceBetweenPointsInKilometers($scope.a1.Latitude, $scope.a1.Longitude, $scope.a2.Latitude, $scope.a2.Longitude);

            $scope.calculating = false;

            //console.log($scope.distance);
        }

        //console.log('distance');
        //console.log(distance);
    });