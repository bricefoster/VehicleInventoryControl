"use strict";

(function core_Module() {
    angular.module('coreModule', ['ngRoute', 'ngResource'])
    .config(Config)
    .factory('AJAXLogin', AJAXLogin)
    .factory('AJAXFactory', AJAXFactory)
    .factory('authFactory', authFactory)
})();