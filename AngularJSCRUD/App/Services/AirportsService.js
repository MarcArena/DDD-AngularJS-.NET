angular.module('myFormApp')
    .factory('airportsService', ['$http', function ($http) {

        var devTestEntryPoint = 'http://localhost:51558/';

        var urlBase = devTestEntryPoint + 'api/airports';

        var dataFactory = {};

        dataFactory.getAirports = function () {
            return $http.get(urlBase);
        };

        dataFactory.getAirportsBySearchString = function (searchString) {
            return $http.get(urlBase + '?searchString=' + searchString);
        };

         dataFactory.getAirportsBySearchString = function (searchString) {
            return $http.get(urlBase + '?searchString=' + searchString);
        };

        dataFactory.getDistanceBetweenAirports = function (airport1, airport2) {

        }

        return dataFactory;

    }]);