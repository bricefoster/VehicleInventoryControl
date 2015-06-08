"use strict";

// Though the size of this application does not necessarily warrant a multi-module Angular architecture, it does provide a foundation for future development
(function umbrella_Module() {
    angular.module('umbrellaModule', ['coreModule', 'ECPModule', 'adminHomeModule', 'registrationModule', 'adminSearchDriversModule', 'adminVehicleInfoModule', 'adminVehicleUpdateModule', 'driverCheckInModule', 'driverHomeModule', 'driverSearchModule', 'commonModule', 'mapModule']);
})();