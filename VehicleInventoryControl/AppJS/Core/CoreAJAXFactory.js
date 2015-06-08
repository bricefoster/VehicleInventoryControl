"use strict";

function AJAXFactory($resource, $http, $q) {
    function get(url, quantity) {
        console.log("Get AJAXFactory");
        if (quantity === "query") {
            return $resource(url).query();
        }
		if (quantity === "get") {
			return $resource(url).get();
		}
    }

    function post(url, data) {
        console.log("post AJAXFactory");        
        return $resource(url).save(data);
    }

    function put(url, data) {
        console.log("put AJAXFactory");
        var deferred = $q.defer();
        $http({
            url: url,
            method: "PUT",
            data: data
        })
        .success(function (response) {
            console.log("success");
            deferred.resolve(response);
        })
        .error(function (response) {
            console.log("rejected");
            deferred.reject(response);
        })
        return deferred.promise;
    }

    return {
        Get: get,
        Post: post,
        Put: put
    }
}

AJAXFactory.$inject = ['$resource', '$http', '$q'];