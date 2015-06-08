"use strict";

(function common_Module() {
    angular.module('commonModule', [])
    .controller('commonNavigationController', commonNavigationController)
    .factory('commonDateFactory', commonDateFactory)
    .factory('commonValidationFactory', commonValidationFactory)
    .factory('commonCommunicationFactory', commonCommunicationFactory)
})();