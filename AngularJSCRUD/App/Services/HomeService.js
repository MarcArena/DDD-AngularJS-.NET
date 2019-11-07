angular.module('myFormApp')
    .factory('homeService', ['$http', function ($http) {
        
        var devTestEntryPoint = 'http://localhost:51558/';

        var urlBase = devTestEntryPoint + 'api/tiles';

        var dataFactory = {};

        dataFactory.getTiles = function () {
            return $http.get(urlBase);
        };

        return dataFactory;

    }]);