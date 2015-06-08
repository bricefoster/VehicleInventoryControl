var Google = {
    map: '',
    geocoder: '',
    GoogleIntitialize: function () {
        var mapOptions = {
            center: new google.maps.LatLng(29.734023, -95.317695), zoom: 17, disableDefaultUI: true,
            zoomControl: true, panControl: true, mapTypeControl: true, scaleControl: true, streetViewControl: true,
            overviewMapControl: true,
        };

        this.map = new google.maps.Map(document.getElementById("mapDiv"), mapOptions);
        this.addButtons(this.map);
    },
    addButtons: function (map) {
        document.getElementById('btnTerrain').addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.TERRAIN);
        });
        document.getElementById('btnHybrid').addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.HYBRID);
        });
        document.getElementById('btnRoadmap').addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.ROADMAP);
        });
        document.getElementById('btnSatellite').addEventListener('click', function () {
            map.setMapTypeId(google.maps.MapTypeId.SATELLITE);
        });
    },
    //var centerMarker = new google.maps.Marker({ icon: imageURL, position: new google.maps.LatLng(29.734023, -95.317695), map: map, title: "State Department of Health Services" });

    geocodeAddress: function () {
        this.geocoder = new google.maps.Geocoder();
        var address = document.getElementById("address").value;
        this.geocoder.geocode({ 'address': address },
            function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    this.map.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({ map: map, position: results[0].geometry.location });
                    this.map.setZoom(17);
                    this.map.panTo(marker.position)
                } else {
                    alert("Geocode failed with the following error: " + status);
                }
            });
    },
    calcRoute: function () {
        var directionsService = new google.maps.DirectionsService();
        var directionsDisplay;
        directionsDisplay = new google.maps.DirectionsRenderer();
        directionsDisplay.setMap(this.map);
        directionsDisplay.setPanel(document.getElementById("directionsPanel"));

        var start = new google.maps.LatLng(29.734023, -95.317695);
        var end = document.getElementById("location").value;
        //custom start location, if you want something other than the state health department, is this line:
        //var start = document.getElementById("customStartLocation").value;
        //and if you do that, don't forget to comment-in the input box down below
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.TravelMode.DRIVING
        };
        directionsService.route(request, function (result, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(result);
            }
        })
    }
};