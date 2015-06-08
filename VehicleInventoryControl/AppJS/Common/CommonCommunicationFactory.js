"use strict";

function commonCommunicationFactory($rootScope) {
    var comm = {};

    comm.message;

    comm.input = function (value) {
        this.message = value;
        this.broadcast();
        console.log("input broadcast");
    };

    comm.broadcast = function () {
        $rootScope.$broadcast('handleReveal');
        console.log("broadcasting");
    };
    
    return comm;
}

commonCommunicationFactory.$inject = ['$rootScope'];