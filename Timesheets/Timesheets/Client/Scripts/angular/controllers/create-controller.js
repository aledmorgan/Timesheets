'use strict';

angular.module('timesheetsApp.controllers', [])
    .controller('CreateController', ['$scope', 'timesheetService', function ($scope, timesheetService) {
        $scope.timesheetId = 0;
        $scope.editMode = true;
        $scope.request = {};

        $scope.createSuccess = false;
        $scope.createError = false;
        $scope.searchUrl = '';

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

        $scope.resetStatusFlags = function () {
            $scope.createError = false;
            $scope.createSuccess = false;
        }

        $scope.generateSearchUrl = function () {
            var url = '/#/timesheets';
            url += '?candidateName=' + $scope.request.CandidateName;
            url += '&clientName=' + $scope.request.ClientName;
            url += '&dateFrom=' + $scope.request.PlacementStartDate;
            url += '&dateTo=' + $scope.request.PlacementEndDate;

            return url;
        }

        $scope.getMappedControllerRequest = function () {
            var request = {
                Id: $scope.request.Id,
                CandidateName: $scope.request.CandidateName,
                ClientName: $scope.request.ClientName,
                JobTitle: $scope.request.JobTitle,
                PlacementStartDate: ukFormattedMoment($scope.request.PlacementStartDate),
                PlacementEndDate: ukFormattedMoment($scope.request.PlacementEndDate),
                PlacementType: $scope.request.PlacementType
            };

            return request;
        }

        $scope.submit = function (valid) {
            if (valid) {
                $scope.loading = true;
                $scope.resetStatusFlags();

                var requestObject = $scope.getMappedControllerRequest();

                var request = timesheetService.createTimesheet(requestObject);
                request.then(function (response) {
                    $scope.createSuccess = true;
                    $scope.searchUrl = $scope.generateSearchUrl();
                }).catch(function (response) {
                    $scope.createError = true;
                }).finally(function () {
                    $scope.loading = false;
                });
            }
        }
    }])