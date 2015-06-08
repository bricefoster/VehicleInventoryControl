"use strict";

// Note-Cbiroan, 3 Jan 2015: This controller is under development and testing.
function driverSearchController($scope, AJAXFactory, commonCommunicationFactory) {
    $scope.reveal = false;

    $scope.reserve = function (data) {
        console.log(data);
        //$scope.reservation.server.reserve(data.id); // For the moment, send this first and let the api controller handle the entry into the repository. But ideally, we should be letting the hub handle entry into the repository.
        AJAXFactory.Post('/api/Driver/Reserve/', { Id: data.vehicleId, dateStart: data.dateStart, dateEnd: data.dateEnd }).$promise.then(
           function (response) { // on success
               console.log(response);
               $scope.driver_Vehicles[$scope.driver_Vehicles.indexOf(data)].isReserved = true;
               $scope.driver_Vehicles[$scope.driver_Vehicles.indexOf(data)].vehicleId = response.id;
               $scope.driver_Vehicles[$scope.driver_Vehicles.indexOf(data)].dateStart = response.dateStart;
               $scope.driver_Vehicles[$scope.driver_Vehicles.indexOf(data)].dateEnd = response.dateEnd;
               console.log($scope.driver_Vehicles[$scope.driver_Vehicles.indexOf(data)].dateEnd);
               console.log($scope.driver_Vehicles[$scope.driver_Vehicles.indexOf(data)].isReserved);
               console.log($scope.driver_Vehicles[$scope.driver_Vehicles.indexOf(data)]);
               console.log($scope.driver_Vehicles);
               console.log("successful reservation");
           },
           function () { // on error
               console.log("rejected reservation");
           });
    }

    $scope.cancel = function (data) {
        console.log($scope.driver_Vehicles);
        AJAXFactory.Post('/api/Driver/Remove/' + data.vehicleId).$promise.then(
            function () {
                console.log("Canceled reservation");
                data.isReserved = false;
            },
            function () {
                alert("Failed to cancel reservation");
            })
    }

    $scope.retrieve = function (data) {
        console.log(data);
        AJAXFactory.Post('/api/Driver/Search/', { dateStart: data.dateStart, dateEnd: data.dateEnd }).$promise.then(
            function (response) { // On success
                $scope.driver_Vehicles = response.vehicleSearchCascade;
                console.log(response.vehicleSearchCascade);
            },
            function (response) { // On error
                console.log("Error attempting to retrieve data");
            });
    }

    $scope.$on('handleBroadcast', function (e) {
        if (commonCommunicationFactory.message) {
            console.log("receiving broadcast");
            $scope.retrieve()
        }
    });
    // Design inquistion-Cbiroan, 03 Jan 2015: Move SignalR to a core factory?
    $scope.challenge = function () {
        $scope.retrieve();
        //$scope.reservation = $.connection.reservation;

        //// Incoming responses from the SignalR hub.
        //$scope.reservation.client.notify = function onNotification(response) {
        //    console.log("inside signalR");
        //    console.log(response);
        //    // Note-Cbiroan, 3 2015: When binding data to Angular, we must manually initiate a digest cycle. This syntax is $apply. Please note that $apply does not require the controller to inject other dependencies.
        //    alert("This is where we would disable or hide the button the reserve: " + response);
        //}

        //$.connection.hub.error(function (err) {
        //    console.log("An error occured: " + err);
        //});
        //$.connection.hub.logging = true; // Debugging
        //$.connection.hub.start(); // Connection start should be last. Any necessary objects and methods should be defined before starting the connection.

    };
}

driverSearchController.$inject = ['$scope', 'AJAXFactory', 'commonCommunicationFactory'];