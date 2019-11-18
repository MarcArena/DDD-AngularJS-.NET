﻿angular.module('myFormApp')
    .factory('CalculationsService', ['$http', function ($http) {

        var devTestEntryPoint = 'http://localhost:51558/';

        var urlBase = devTestEntryPoint + 'api/tiles';

        var dataFactory = {};

        /**
             * Returns the distance between 2 points of coordinates in Google Maps
             * 
             * @see https://stackoverflow.com/a/1502821/4241030
             * @param lat1 Latitude of the point A
             * @param lng1 Longitude of the point A
             * @param lat2 Latitude of the point B
             * @param lng2 Longitude of the point B
 */

        dataFactory.getDistanceBetweenPoints = function (lat1, lng1, lat2, lng2) {
            let R = 6378137;
            let dLat = degreesToRadians(lat2 - lat1);
            let dLong = degreesToRadians(lng2 - lng1);
            let a = Math.sin(dLat / 2)
                *
                Math.sin(dLat / 2)
                +
                Math.cos(degreesToRadians(lat1))
                *
                Math.cos(degreesToRadians(lat1))
                *
                Math.sin(dLong / 2)
                *
                Math.sin(dLong / 2);

            let c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
            let distance = R * c;

            return distance;
        };

        return dataFactory;

    }]);