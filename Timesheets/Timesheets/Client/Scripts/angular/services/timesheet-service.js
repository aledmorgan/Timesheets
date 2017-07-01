'use strict';

angular.module('timesheetsApp.services', [])
    .factory('timesheetService', ['$http', function ($http) {
        return {
            getTimesheets: function () {
                return $http.post(
                    '/ServiceController/GetAllTimesheets'
                ).then(
                    function (response) {
                        return response;
                    },
                    function (response) {
                        console.log('Error retrieving timesheets');
                    }
                );
            }
        }
    }]);