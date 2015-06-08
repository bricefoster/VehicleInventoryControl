"use strict";

function driverHomeController($scope, AJAXFactory, $location, $window) {
    console.log("Im in");
    $scope.challenge = function (data) {
        console.log("challenging inside driver home")
        AJAXFactory.Get('api/Driver/GetCascade/', 'get').$promise.then(function (response) {

            $scope.driver_Vehicles = response;
            console.log($scope.driver_Vehicles);
            console.log(response.vehicleDriverCascade);

            console.log("Inside the Get drive_Vehicles");

        }, function (error) { Console.log("error") });
    }

    $scope.cancel = function (data, target) {

        var confirmDelete = $window.confirm("Are you sure you want to cancel this reservation?");

        if (confirmDelete == true) {
            AJAXFactory.Post('api/Driver/Remove/' + data.vehicleId, undefined).$promise.then(function (response) {
                var source = document.getElementById(data.licPlate);
                source.deleteRow(target);
                console.log(source.rows.length);
                if (source.rows.length == 0) {
                    console.log("eliminating row")
                    var index = document.getElementById(data.vehicleId).rowIndex;
                    console.log(index);
                    document.getElementById("tableDriverHome").deleteRow(index);
                }
                console.log("Inside the cancel function in DriverHomeController");
            },
            function () {

            });

        }
        else {
            $window.alert("Okay, your reservation is safe.");
        }
    }

    $scope.checkIn = function (data) {
        var wantToReserve = $window.confirm("You are about to check in. Do you wish to continue?");
        console.log(data);
        if (wantToReserve == true) {
            for (var prop in data) {
                localStorage.setItem(prop, data[prop]);
            }            
        }
        $location.path('/CheckIn');
    }
}


driverHomeController.$inject = ['$scope', 'AJAXFactory', '$location', '$window'];