"use strict";

function adminVehicleUpdateController($scope, $location, AJAXFactory, AJAXLogin, commonValidationFactory) {
    $scope.post = function (automobile) {
        if (commonValidationFactory.Validate(automobile)) {
            AJAXFactory.Post('/api/AdminVehicle/AddVehicle/', automobile).$promise.then(
                function () {
                    alert("Successful added vehicle with license plate " + automobile.licPlate);
                },
                function () {
                    alert("Rejected");
                });
        }
        else {
            alert("Please properly complete all fields.") // This is temporary.
        }
    }
    // every controller has to have a challenge
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
                // Link to communication factory later
                $scope.get();
            }
            else if (AJAXLogin.role() === "Driver") {
                console.log("driver");
                $location.path('/Driver');
            }
            else {
                console.log("failed to find role")
            }
        }
    }
}

adminVehicleUpdateController.$inject = ['$scope', '$location', 'AJAXFactory', 'AJAXLogin', 'commonValidationFactory']