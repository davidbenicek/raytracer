const $ = require('jquery');


exports.sendToApi = function(dataJSON){

    dataJSON = {
        "objects":
        [
            {"shape":"sphere","size":{"x":30,"y":30,"z":30},"point":{"x":-50,"y":0,"z":60},
            "color":{"r":0.0,"g":0.0,"b":1},"material":"flat"},
            {"shape":"sphere","size":{"x":40,"y":40,"z":40},"point":{"x":50,"y":0,"z":0},
            "color":{"r":1,"g":1,"b":1},"material":"flat"}
        ],
        "environment":
        {
            "fileName":"test",
            "winFrame":{"Width":800,"Height":600 },
            "background":{"r":0.2,"g":0.4,"b":0.4},
            "camera" : { "position":{"x":0,"y":0,"z":500}, "lookAt": {"x":-5,"y":0,"z":0}, "distanceViewPlane":850 },
            "lights":[
                {"rgbColor":{"r":0.3,"g":0.3,"b":0.3}, "intensity": 1 },
                {"position":{"x":0,"y":55,"z":95},"rgbColor":{"r":1.0,"g":0,"b":0}, "intensity": 0.5},
                {"position":{"x":50,"y":55,"z":75},"rgbColor":{"r":1.0,"g":0,"b":1.0}, "intensity": 0.4}
            ]
        }
    };

    $.ajax({
        type: 'POST',
        url: 'http://10.75.219.64:1200/api/Render',
        data: JSON.stringify(dataJSON),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(d)
        {
            console.log(d);
        },
        error: function(d)
        {
            console.log(d);
        }
    });
}