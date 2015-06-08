"use strict";

function authFactory($q, $window) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if (window.localStorage.getItem('958tgj&gj%4fsghjofdrjeuour09f8&g&^DBsdfjk4RFfjds5665ru$8f9RFdfjfkldsaj4$DFHZT')) {
                config.headers.Authorization = "Bearer " + $window.localStorage.getItem('958tgj&gj%4fsghjofdrjeuour09f8&g&^DBsdfjk4RFfjds5665ru$8f9RFdfjfkldsaj4$DFHZT'); // Authorization is required for the AJAX call
            }
            return config || $q.when(config);
        }
    }
}

authFactory.$inject = ['$q', '$window']