"use strict";

function commonNavigationController($scope, $location, AJAXFactory, AJAXLogin, commonCommunicationFactory) {
    $scope.$on('handleReveal', function () {
        console.log("Revealing, achtung");
        $scope.challenge();
    });

    $scope.generateDays = function (month) {
        $scope.days = commonDateFactory.Generate(month);
        console.log(month);
        console.log("Challenging");
    }

    $scope.generate_Days = function (month) {
        $scope._days = commonDateFactory.Generate(month);
    }

    $scope.logout = function () {
        $scope.reveal = false;
        AJAXLogin.logOut();
        $location.path('/');
    }

    $scope.search = function () {
        // Refactor
        if (commonDateFactory.BuildDate($scope.buildReserveStartDate) && commonDateFactory.BuildDate($scope.buildReserveEndDate) && commonDateFactory.BuildDate($scope.buildReserveStartDate) < commonDateFactory.BuildDate($scope.buildReserveEndDate)) {
            // Store to the factory
            localStorage.setItem('sM', $scope.buildReserveStartDate.month);
            localStorage.setItem('sD', $scope.buildReserveStartDate.day);
            localStorage.setItem('sY', $scope.buildReserveStartDate.year);
            localStorage.setItem('Em', $scope.buildReserveEndDate.month);
            localStorage.setItem('Ed', $scope.buildReserveEndDate.day);
            localStorage.setItem('Ey', $scope.buildReserveEndDate.year);
            // Broadcast and navigate
            commonCommunicationFactory.input(true);
            console.log("navigating");
            $location.path('/Reservations');
        }
        else {
            alert("Please ensure both start and end dates are complete before searching");
        }
    }

    $scope.challenge = function () {
        console.log("challenging");
        if (!AJAXLogin.challenge()) {
            localStorage.clear();
            console.log("rejected challenge");
        }
        else {
            $scope.reveal = true;
            var check = localStorage.getItem('s')
            if (check >= 9000 && check < 10001) {
                $scope.duo = true;
                $scope.admin = true;
                $scope.driver = true;
            }
            else if (check > 0 && check < 1001) {
                $scope.duo = true;
                $scope.admin = false;
                $scope.driver = true;
            }
            else {
                localStorage.clear();
                $location.path('/');
            }
            console.log($scope.duo);
            console.log($scope.admin);
            console.log($scope.driver);
        }
    }

}

commonNavigationController.$inject = ['$scope', '$location', 'AJAXFactory', 'AJAXLogin', 'commonCommunicationFactory'];