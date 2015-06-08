"use strict";

// Note-Cbiroan, 04 Jan 2015: For the moment, this factory is restricted to the registration module.
function commonDateFactory() {

    // Generates the amount of days with respect to month. This shouldn't be in a factory, but it is better than being in a controller
    var generate = function (month) {
        var days = [];
        if (month == 0 || month == 2 || month == 4 || month == 6 || month == 7 || month == 9 || month == 11) {
            for (var a = 1; a < 32; a++) {
                days.push(a);
            }
            return days;
        }
        if (month == 3 || month == 5 || month == 8 || month == 10) {
            for (var b = 1; b < 31; b++) {
                days.push(b);
            }
            return days;
        }
        if (month == 1 && (new Date().getFullYear % 4 !== 0)) {
            for (var c = 1; c < 29; c++) {
                days.push(c);
            }
            return days;
        }
        if (month == 1 && (new Date().getFullYear % 4 === 0)) {
            for (var d = 1; d < 30; d++) {
                days.push(d);
            }
            return days;
        }
    }

    var pack = function (model, dl, ins) { // Check if every model is valid.
        if(model.password != model.passwordConfirm){ // Check for password confirmation
            return null;
        }
        for (var prop in model) { // Check for truthy/falsey. Note-Cbiroan, 5 Jan 2015: we need to add type validation
            console.log(prop);
            if (!prop) {
                return null;
            }
        }

        if (!buildDate(dl)) { // Truthy/falsey
            return null;
        }
        model.DLExpDate = buildDate(dl);

        if (!buildDate(ins)) { // Truthy/falsey
            return null;
        }
        model.InsExpDate = buildDate(ins);
        console.log(dl);
        console.log(ins);
        console.log(model);
        return model;
    }

    var buildDate = function(dl) {
        for (var date in dl) { // Check for truthy/falsey
            if (!date) {
                return null;
            }
        }
        return new Date((20 + dl.year), dl.month, dl.day, 0, 0, 0, 0);
    }

    return {
        Generate: generate,
        Pack: pack,
        BuildDate: buildDate
    }
}

