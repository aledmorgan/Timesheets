'use strict';

angular.module('timesheetsApp.controllers', [])
    .controller('CreateController', ['$scope', 'timesheetService', function ($scope, timesheetService) {
        $scope.timesheetId = 0;
        $scope.editMode = true;
        $scope.request = {};

        $scope.createSuccess = false;
        $scope.updateSuccess = false;

        $scope.loading = false;

        $scope.$on('$routeChangeSuccess', function () {
            $scope.setDefaults();
        });

        $scope.setDefaults = function () {
            $scope.request.Id = '';
            $scope.request.CandidateName = '';
            $scope.request.ClientName = '';
            $scope.request.JobTitle = '';
            $scope.request.PlacementStartDate = '';
            $scope.request.PlacementEndDate = '';
            $scope.request.PlacementType = '';
        }

        $scope.submit = function (valid) {
            if (valid) {
                $scope.loading = true;
                $scope.createSuccess = false;
                $scope.createError = false;

                var request = timesheetService.createTimesheet($scope.request);
                request.then(function (response) {
                    $scope.createSuccess = true;
                }).catch(function (response) {
                    $scope.createError = true;
                }).finally(function () {
                    $scope.loading = false;
                });
            }
        }
    }])