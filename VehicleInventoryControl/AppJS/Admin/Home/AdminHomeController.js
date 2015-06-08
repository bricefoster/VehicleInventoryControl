"use strict";

//this page needs to display all the vehicles
//any time we are making ANY ajax request, use AJAX CORE FACTORY
function adminHomeController($scope, $location, $window, AJAXFactory, AJAXLogin) {
    $scope.ApplicationUser = {};

    $scope.getVehicles = function () {
        console.log("Retrieving vehicles for the admin");
        AJAXFactory.Get('/api/AdminVehicle/GetAllVehiclesAdmin/', "get").$promise.then(
            function (response) { // May break
                $scope.vehicles = response;
                console.log($scope.vehicles);
            },
        function () {
            alert("Failed to retrieve data from the server. Please contact technical support for a resolution.")
        })
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
                alert("Failed to cancel reservation");
            });

        }
    }

    $scope.getVehicle = function (Id) {
        localStorage.setItem("Id", Id);
        $location.path('/Vehicle/Detail'); //reroute
    }

    $scope.challenge = function () {
        console.log("Challenging");
        if (!AJAXLogin.challenge() && !AJAXLogin.role) { // redirect to login and clear the local storage
            $location.path("/");
            localStorage.clear();
        }
        else {
            console.log("checking roles");
            console.log(AJAXLogin.role());
            if (AJAXLogin.role() === "Admin") {
                console.log("admin");
                $scope.reveal = true; // Link to communication factory later
                $scope.getVehicles();
            }
            else if (AJAXLogin.role() === "Driver") {
                console.log("driver");
                $scope.reveal = false;
                $location.path('/Driver');
            }
            else {
                console.log("failed to find role")
            }
        }
    }
}



adminHomeController.$inject = ['$scope', '$location', '$window', 'AJAXFactory', 'AJAXLogin'];