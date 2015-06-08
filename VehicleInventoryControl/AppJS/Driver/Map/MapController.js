"use strict";

function mapController($scope, AJAXFactory, $location) {
    $scope.loadScript = function () {
        var script = document.createElement('script');
        script.type = 'text/javascript';
          script.src = 'https://maps.googleapis.com/maps/api/js?key=AIzaSyDsX-G8EwyoT5POMuM0I1OTeiwgJABg6O8&' +
      'callback=Google.GoogleIntitialize';
        document.getElementById("google-map-api").appendChild(script);
    }
    //$scope.driver_Vehicles = AJAXFactory.Get('api/mapController').$promise.then(function (response) { }, function (error) { Console.log("error") });

}

mapController.$inject = ['$scope', 'AJAXFactory', '$location'];