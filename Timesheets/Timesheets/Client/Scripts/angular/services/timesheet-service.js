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
            },

            createTimesheet: function (request) {
                return $http.post(
                    '/ServiceController/CreateTimesheet',
                    {newTimesheets: request}
                ).then(
                    function (response) {
                        return response;
                    },
                    function (response) {
                        console.log('Error creating timesheet');
                    }
                    );
            }
        }
    }]);