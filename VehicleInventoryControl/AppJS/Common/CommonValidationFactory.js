"use strict";

function commonValidationFactory() {
    var validate = function (vm) { // Validates if fields are null. Type validation needs to be added
        for (var p in vm) {
            console.log(p);
            if (!p) {
                return false;
            }
        }
        return true;
    }

    return {
        Validate: validate
    }
}