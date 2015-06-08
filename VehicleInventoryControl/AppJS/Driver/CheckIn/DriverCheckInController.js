"use strict";

function driverCheckInController($scope, AJAXFactory, $location, $window) {
    // Take information from view, make into object


    $scope.submitted = false;
    $scope.submitting = false;

    $scope.submitForm = function (data) {
        $scope.submitted = true;
        data.licPlate = localStorage.getItem('licPlate');
        data.make = localStorage.getItem('make');
        data.model = localStorage.getItem('model');
        data.year = localStorage.getItem('year');
        data.vehicleId = localStorage.getItem('vehicleId');
        data.dateStart = localStorage.getItem('dateStart');
        data.dateEnd = localStorage.getItem('dateEnd');
        data.dateReserved = localStorage.getItem('dateReserved');
        data.vehicleId = localStorage.getItem('vehicleId');
        console.log("submit form DriverCheckIn");
        console.log(data);
        //if ($scope.data.endingMileage.$error && $scope.data.numberOfPassengers.$error && $scope.data.gallons.$error && $scope.data.pricePerGallon.$error
        //        && $scope.data.destination.$error && $scope.data.comments.$error && $scope.data.dateStart.$error && $scope.data.dateEnd.$error
        //        && $scope.data.dateReserved.$error) {
        AJAXFactory.Post('/api/Driver/Report/', data).$promise.then( // on the promise is resolved, one of the following 
            function (response) {
                $scope.submitting = true;
                $location.path('/Driver');
               
            }, // On success, re route driver to home page
            function () {

            }); // on error, do not re-route, highlight fields that need to be corrected. 404 not found or if the 
        // validation failed on the back end. Everything on the view is required; therefore every text/text area should have a value 409?.
    }
    //        else{
    //            $window.alert('Please fix any validation errors and try again.');
    //}
    //    }
}

driverCheckInController.$inject = ['$scope', 'AJAXFactory', '$location', '$window'];

// AJAXFactory.Post(url, data)