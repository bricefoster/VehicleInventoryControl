"use strict";

function ECPLoginController($scope, $location, AJAXFactory, AJAXLogin, commonCommunicationFactory) {
    $scope.Login = function () {
        console.log($scope.user);
        AJAXLogin.logIn($scope.user).then(
            function (response) { // on success
                //communicationNavBarFactory.input(true);
                console.log(response);
                AJAXFactory.Get('/api/AuthorizationRedirect/', "get").$promise.then(
                    function (response) {
                        console.log(response);
                        if (response.redirectId > 0 && response.redirectId < 1001) {
                            console.log('navigating');
                            localStorage.setItem('s', response.redirectId);
                            $location.path('/Driver');
                            commonCommunicationFactory.input(true);
                        }
                        else if (response.redirectId >= 9000 && response.redirectId < 10001) {
                            console.log('navigating');
                            localStorage.setItem('s', response.redirectId);
                            $location.path('/Admin');
                            commonCommunicationFactory.input(true);
                        }
                        else {
                            console.log("Failed to navigate");
                        }
                    },
                    function (response) {
                        console.log("Rejected")
                    });
                 // Change navigation success
            },
            function () { // on reject
                console.log("Rejected login");
            });
    }

    $scope.Logout = function () {
        console.log("loggin out");
        AJAXLogin.logOut();
        $location.path('/');
    }

    $scope.Challenge = function () {
        console.log("challenging");
        if (AJAXLogin.challenge() && AJAXLogin.role) {
            var s = localStorage.getItem('s');
            if (s > 0 && s < 1001) {
                $location.path('/Driver'); // Change this route
                commonCommunicationFactory.input(true);
            }
            else if (s >= 9000 && s < 10001) {
                console.log("Navigating");
                $location.path('/Admin');
                commonCommunicationFactory.input(true);
            }
        }
        else {
            $location.path('/');
            $scope.reveal = true; // Design question. Should we worry about the nav bar? If so, keep this.
            localStorage.clear();
        }
    }
}

ECPLoginController.$inject = ['$scope', '$location', 'AJAXFactory', 'AJAXLogin', 'commonCommunicationFactory'];