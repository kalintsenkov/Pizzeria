(function($) {
  'use strict';

  // Change the values of your latitude and longitude (Map data attributes override these values)
  var Lat = 51.5;
  var Lng = -0.09;

  if ($(".ct-contact-map").length) {
    var i = 0;
    $(".ct-contact-map").each(function(){

      Lat = $(this).data('lat') != undefined ? $(this).data('lat') : Lat;
      Lng = $(this).data('lng') != undefined ? $(this).data('lng') : Lng;

      L.HtmlIcon = L.Icon.extend({

        initialize: function(options) {
          L.Util.setOptions(this, options);
        },

        createIcon: function() {
          var div = document.createElement('div');
          div.innerHTML = this.options.html;
          if (div.classList)
            div.classList.add('leaflet-marker-icon');
          else
            div.className += ' ' + 'leaflet-marker-icon';
          return div;
        },

      });

      var tiles = L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/Canvas/World_Light_Gray_Base/MapServer/tile/{z}/{y}/{x}', {
          attribution: 'Tiles &copy; Esri &mdash; Esri, DeLorme, NAVTEQ',
          maxZoom: 16
        }),
        latlng = L.latLng(Lat, Lng);

      var i = L.map($(this).attr('id'), {
        center: latlng,
        zoom: 16,
        scrollWheelZoom: false,
        layers: [tiles]
      });

      var markerHTML = new L.HtmlIcon({
        html: "<img class='leaflet-marker-icon leaflet-zoom-animated leaflet-interactive' src='assets/img/misc/marker.png' alt='markericon' />",
      });

      L.marker([Lat, Lng], {icon: markerHTML}).addTo(i);
      i++;
    });

  }

})(jQuery);
