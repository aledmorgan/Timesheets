'use strict';

angular.module('timesheetsApp.controllers')
    .controller('IndexController', ['$scope', 'timesheetService', function ($scope, timesheetService) {
        $scope.timesheets = [];
        $scope.filteredTimesheets = [];
        $scope.loading = true;
        $scope.error = false;

        $scope.candidateName = '';
        $scope.clientName = '';
        $scope.dateFrom = '';
        $scope.dateTo = '';

        $scope.$on('$routeChangeSuccess', function () {
            $scope.init();
        });

        $scope.$watchCollection('[candidateName, clientName, dateFrom, dateTo]', function () {
            $scope.filterTimesheets();
        });

        $scope.init = function () {
            $scope.loadTimesheets();
        }

        $scope.getFormattedDate = function (date) {
            return moment(date).format("DD/MM/YYYY");
        }

        $scope.loadTimesheets = function () {
            var request = timesheetService.getTimesheets();
            request.then(function (response) {
                $scope.timesheets = response.data;
            }).catch(function (response) {
                $scope.error = true;
            }).finally(function () {
                $scope.loading = false;
            });
        }

        //We need to do date comparisons, so it's better to filter in a function than inline html with ng filters
        $scope.filterTimesheets = function () {
            $scope.filteredTimesheets = [];

            $scope.timesheets.forEach(function (timesheet) {
                if ($scope.candidateName === '' || timesheet.CandidateName.toLowerCase().indexOf($scope.candidateName) >= 0) {
                    if ($scope.clientName === '' || timesheet.ClientName.toLowerCase().indexOf($scope.clientName) >= 0) {
                        if ($scope.dateFrom === '' || moment(timesheet.StartDate) >= ukFormattedMoment($scope.dateFrom)) {
                            if ($scope.dateTo === '' || moment(timesheet.EndDate) <= ukFormattedMoment($scope.dateTo)) {
                                $scope.filteredTimesheets.push(timesheet);
                            }
                        }
                    }
                }
            });
        }
    }]);
