'use strict';

angular.module('timesheetsApp',
    [
        'timesheetsApp.controllers',
        'timesheetsApp.services',
        'timesheetsApp.directives',
        'ngRoute'
    ]
).config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/timesheets', {
            templateUrl: 'application/index',
            controller: 'IndexController'
        })
        .when('/create/', {
            templateUrl: 'application/create',
            controller: 'CreateController'
        })
        .when('/timesheets/:id/', {
            templateUrl: 'application/timesheet',
            controller: 'TimesheetController'
        })
        .otherwise({ redirectTo: '/timesheets/' });
}]);

