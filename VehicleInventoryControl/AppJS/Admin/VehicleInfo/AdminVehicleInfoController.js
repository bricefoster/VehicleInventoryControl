"use strict";

function adminVehicleInfoController($scope, AJAXLogin, AJAXFactory) {
    $scope.get = function () {
        var Id = localStorage.getItem("Id");
        AJAXFactory.Get('/api/AdminVehicle/GetVehicleDetail/' + Id, "get").$promise.then(
            function (response) {
                $scope.trucks = response;
                console.log($scope.trucks);
                console.log("Retrieving details");
            },
            function () {
                console.log("Failed to retrieive");
            })

    }

    $scope.editVehicle = function (vehicle) {
        AJAXFactory.Post('/api/AdminVehicle/EditVehicle', vehicle).$promise.then(function () {
            console.log("successfully changed");
        },
        function () {
            console.log("Rejected change");
        });
    }

    $scope.removeVehicle = function (licPlate) {
        AJAXFactory.Post('/api/AdminVehicle/Remove/' + licPlate).$promise.then(function () {
            $location.path('/Admin');
        },
        function () {
            alert("Failed to remove this vehicle from the data base. Please notify the database manager"); // This is temporary.
        });
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
                $scope.get();
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

adminVehicleInfoController.$inject = ['$scope', 'AJAXLogin', 'AJAXFactory']