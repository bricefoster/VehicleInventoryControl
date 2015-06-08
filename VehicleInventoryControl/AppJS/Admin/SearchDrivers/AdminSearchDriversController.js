"use strict";

// If time permits, refactor

function adminSearchDriversController($scope, $location, AJAXLogin, AJAXFactory) {
    $scope.reveal = false;

    $scope.get = function () {
        AJAXFactory.Get("/api/AdminDriver/GetCascade/", "get").$promise.then(function (response) {
            $scope.drivers = response;
            console.log(response);
        },
        function () {
            alert("Failed to retrieve data. Please contact techincal support for a resolution.")
        })
    }

    $scope.details = function (driver) {
        localStorage.setItem('ldkx', driver.id);
        $location.path('/Registration');
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

adminSearchDriversController.$inject = ['$scope', '$location', 'AJAXLogin', 'AJAXFactory'];