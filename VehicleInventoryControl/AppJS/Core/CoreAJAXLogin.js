"use strict";

function AJAXLogin($http, $q, $location) {
	function logIn(user) {
		var deferred = $q.defer();
		$http({
			url: '/Token',
			method: 'POST',
			contentType: 'application/x-www-form-urlencoded',
			data: 'username=' + user.username + '&password=' + user.password + '&grant_type=password'
		})
		.success(function (data) {
		    localStorage.setItem('958tgj&gj%4fsghjofdrjeuour09f8&g&^DBsdfjk4RFfjds5665ru$8f9RFdfjfkldsaj4$DFHZT', data.access_token);
		    console.log("success in AJAXLogin");
			deferred.resolve();
		})
		.error(function (data) {
		    localStorage.removeItem('958tgj&gj%4fsghjofdrjeuour09f8&g&^DBsdfjk4RFfjds5665ru$8f9RFdfjfkldsaj4$DFHZT');
		    console.log("Failure in AJAXLogin");
		    console.log(data);
			deferred.reject();
		});
		return deferred.promise;
	}

	function logOut() {
	    console.log("logged out");
	    localStorage.clear();
	}
	
	function challenge() {
		if(localStorage.getItem('958tgj&gj%4fsghjofdrjeuour09f8&g&^DBsdfjk4RFfjds5665ru$8f9RFdfjfkldsaj4$DFHZT')) {
			return true;
		}
		return false;
	}

	function role() { // use truthy/ falsey
	    var check = localStorage.getItem('s')
	    if (check > 9000 && check < 10001) {
	        return "Admin";
	    }
	    if (check > 0 && check < 1001) {
            return "Driver"
	    }
	    return null;
	}

	return {
	    logIn: logIn,
	    logOut: logOut,
	    challenge: challenge,
	    role: role
	}
}

AJAXLogin.$inject = ['$http', '$q', '$location'];