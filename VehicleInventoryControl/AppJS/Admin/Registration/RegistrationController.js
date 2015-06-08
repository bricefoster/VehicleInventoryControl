"use strict";
// Please remind me to enable any necessary code that is commented out.
// Most of this should be handled by a directive or a service. Anything else but the controller. But for now, keep in the controller. 
function registrationController($scope, $location, AJAXFactory, AJAXLogin, commonDateFactory) {
    $scope.load = false;
    $scope.candidate = {};

    $scope.roles = [{
        "value": "Admin",
        "text": 'Administrator'
    }, {
        "value": "Driver",
        "text": 'Driver'
    }];

    $scope.remove = function (candidate) {
        candidate.password = "fdsda";
        candidate.passwordConfirm = "fdsda";
        candidate.role = "fdsda";
        AJAXFactory.Post('/api/AdminDriver/Remove/', candidate).$promise.then(
            function () {
                alert("Successfully removed driver.");
                $location.path('/Drivers');
            },
            function () {
                alert("Failed to remove driver. Please contact technical support for a resolution.");
            })
    }

    $scope.edit = function () {
        $scope.isEditing = true;
    }

    $scope.save = function (candidate) {
        candidate.password = "fdsda";
        candidate.passwordConfirm = "fdsda";
        candidate.role = "fdsda";
        candidate.id = localStorage.getItem("ldkx");
        console.log(candidate);
        AJAXFactory.Post('/api/AdminDriver/Edit/', candidate).$promise.then(
            function () {
                $scope.isEditing = false;
                $location.path('/Drivers');
            },
            function () {
                alert('Failed to update.');
            })
    }

    $scope.cancel = function () {
        $scope.isEditing = false;
    }

    $scope.submitForm = function (candidate) {
        // This is temporary. Move validation to a custom directory. For now, the back end is doing true validation.
        console.log("submit form");
        candidate.role = candidate.role.value;
        console.log(candidate);
        if (candidate) {
            AJAXFactory.Post('/api/AdminDriver/Post/', candidate).$promise.then(
                function () {
                    $location.path('/Admin');
                    // Note-Cbiroan, 31 Dec 2014: On success, where do we want to navigate after a successful navigation?
                }, // on success
                function () {
                    console.log('Rejected registration');
                    // Note-Cbiroan, 31 Dec 2014: On error, what messages do we want to display?
                }) // on error
        }
        else {
            console.log("Rejected validation");
        }
    }

    $scope.get = function () {
        var target = localStorage.getItem('ldkx')
        AJAXFactory.Get('/api/AdminDriver/GetDriver/' + target, 'get').$promise.then(
            function (response) {
                $scope.details = response;
            },
            function () {
                alert("Unable to retrieve data. If problem persists, please contact technical support for a resolution");
            })
    }

    $scope.challenge = function () {
        console.log("challenging");
        if (!AJAXLogin.challenge()) {
            localStorage.clear();
            console.log("rejected challenge");
        }
        else {
            $scope.load = true;
            console.log($scope.years);
            if (localStorage.getItem('ldkx')) {
                $scope.reveal = true;
                 
                $scope.get();
                console.log($scope.reveal)
            }
            else {
                console.log($scope.reveal)
                $scope.reveal = false;
            }
        }
    }
}

registrationController.$inject = ['$scope', '$location', 'AJAXFactory', 'AJAXLogin', 'commonDateFactory']