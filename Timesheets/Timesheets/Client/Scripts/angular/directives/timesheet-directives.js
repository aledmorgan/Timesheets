'use strict';

angular.module('timesheetsApp.directives', [])
    .directive("momentValidDate", function () {
        return {
            require: "ngModel",
            restrict: "A",
            link: function (scope, elem, attr, ctrl) {
                ctrl.$validators.momentValidDate = function (value) {
                    if (value === undefined || value === null || value === "") {
                        return true;
                    }

                    return moment(value, ["DD/MM/YYYY"], true).isValid();
                }
            }
        }
    });