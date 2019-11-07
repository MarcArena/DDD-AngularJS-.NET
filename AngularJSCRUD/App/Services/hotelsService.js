angular.module('myFormApp')
    .factory('hotelsService', ['$http', function ($http) {

        var devTestEntryPoint = 'http://localhost:51558/';

        var urlBase = devTestEntryPoint + 'api/hotels';

        var dataFactory = {};

        dataFactory.getHotels = function (destinationId, numberOfNights) {
            return $http.get(urlBase + '?destinationId=' + destinationId + '&numberOfNights=' + numberOfNights);
        };

        return dataFactory;

    }]);