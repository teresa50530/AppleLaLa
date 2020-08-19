function initialize() {
    var myOptions = {
        zoom: 12,
        center: new google.maps.LatLng(24.9639248, 121.2924233), //change the coordinates
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        scrollwheel: false,
        mapTypeControl: false,
        zoomControl: false,
        streetViewControl: false,
    }

    var map = new google.maps.Map(document.getElementById("map-canvas"), myOptions);

    //JSON
    var location = [{
        coordinates: [121.2924233, 24.9639248],
        properties: {
            name: "八德廣豐1號店",
            picture:"https://drive.google.com/uc?export=view&id=1CnumrHhq9xm_DR4GFpVxJ8o-FH-QZGa5",
            address: "桃園區永福西街121號1F",
            phone: "0912-223-349",
            localPhone:"03-361-2466",            
            LineID: "appleandlala"
        }
    },
    {
        coordinates: [121.292558, 25.0106265],
        properties: {
            name: "桃園藝文2號店",
            picture:"https://drive.google.com/uc?export=view&id=1c06mdKKs9mBKbosuQ7EtPlNARsvzqoDe",
            address: "桃園區寶慶路58號2F",            
            phone: "0975-103-030",
            localPhone:"03-215-1088",
            LineID: "applelalayw"
        }

    }];

    // Map Marker
    let marker = [];
    let infowindow = [];
    let _infowindow = ' ';

    for (let i = 0; i < location.length; i++) {
        let lng_lat = location[i].coordinates;
        let _position = new google.maps.LatLng(lng_lat[1], lng_lat[0]);
        marker[i] = new google.maps.Marker({
            map: map,
            position: _position
        })
    }
    //<a href="tel:+4733378901">+47 333 78 901</a>
    location.forEach((item, index) => {
        infowindow[index] = new google.maps.InfoWindow({
            content: `<div class="iw-container">
                            <img src="${item.properties.picture}"width=100></img>
							<div class="iw-title"><p><strong>店名：${item.properties.name}</strong></p></div>
                            <p>地址：${item.properties.address}</p>							
							<a href="tel:+${item.properties.Phone}"><p>手機：${item.properties.phone}</p></a>
                            <a href="tel:+${item.properties.localPhone}"><p>市話:${item.properties.localPhone}</p></a>
							<p>LineID:${item.properties.LineID}</p>
						</div>`
        });
                
        marker[index].addListener('click', function () {
            if (_infowindow !== ' ') {
                _infowindow.close();
                _infowindow = ' ';
            } else {
                infowindow[index].open(map, marker[index]);
                _infowindow = infowindow[index];
            };
            if (marker[index].getAnimation() == null) {
                marker[index].setAnimation(google.maps.Animation.BOUNCE);
            } else {
                marker[index].setAnimation(null);
            };
        })
    });
}
google.maps.event.addDomListener(window, 'load', initialize);