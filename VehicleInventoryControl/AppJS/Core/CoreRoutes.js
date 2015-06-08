"use strict";

function Config($routeProvider, $httpProvider) {
    $routeProvider.when('/', {
        templateUrl: '/AppJS/ECP/ECP.html',
        title: 'Login'
    })
    .when('/Admin', {
        templateUrl: '/AppJS/Admin/Home/AdminHome.html',
        title: 'Administrator'
    })
    .when('/Registration', {
        templateUrl: '/AppJS/Admin/Registration/Registration.html',
        title: 'Registration'
    })
    .when('/Inventory', {
        templateUrl: '/AppJS/Admin/VehicleUpdate/AdminVehicleUpdate.html',
        title: 'Inventory'
    })
    .when('/Vehicle/Detail', {
        templateUrl: '/AppJS/Admin/VehicleInfo/AdminVehicleInfo.html',
        title: 'Details'
    })
    .when('/Drivers', {
        templateUrl: '/AppJS/Admin/SearchDrivers/AdminSearchDrivers.html',
        title: 'Drivers'
    })
    .when('/Driver', {
        templateUrl: '/AppJS/Driver/Home/DriverHome.html',
        title: 'Driver'
    })
    .when('/CheckIn', {
        templateUrl: '/AppJS/Driver/CheckIn/DriverCheckIn.html',
        title: 'CheckIn'
    })
    .when('/Reservations', {
        templateUrl: '/AppJS/Driver/Search/DriverSearch.html',
        title: 'Reservations'
    })
    .when('/Directions', {
        templateUrl: '/AppJS/Driver/Map/Map.html',
        title: "Directions"
    })
    .otherwise({
        redirectTo: '/'
    })

    $httpProvider.interceptors.push('authFactory');
}

Config.$inject = ['$routeProvider', '$httpProvider'];