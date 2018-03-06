'use strict';

const $ = require('jquery');

function formatJSONForBackEnd(dataJSON){

    dataJSON.winFrame.Height = parseInt(dataJSON.winFrame.Height); 
    dataJSON.winFrame.Width = parseInt(dataJSON.winFrame.Width); 
    
    dataJSON.wallPosition = dataJSON.winFrame.Width;

    //Hardcoding camera
    let camera = {
        "position" : {}
    };
    camera.position.x = parseInt(dataJSON.camera.x);
    camera.position.y = parseInt(dataJSON.camera.y);
    camera.position.z = parseInt(dataJSON.camera.z);
    camera["lookAt"] = {x: 0, y: 0, z: 0};
    camera["distanceViewPlane"] = 1500;
    dataJSON["camera"] = camera;

    //Converting background colours to fractions
    dataJSON["background"].r = dataJSON["background"].r/255;
    dataJSON["background"].g = dataJSON["background"].g/255;
    dataJSON["background"].b = dataJSON["background"].b/255;

    //Hardcoding light TODO: For Hitesh
    let light = {};
    light["rgbColur"] = dataJSON["rgbColor"];
    delete dataJSON["rgbColor"];
    light["intensity"] = parseInt(dataJSON["intensity"]);
    delete dataJSON["intensity"];
    light["position"] = dataJSON["position"];
    delete dataJSON["position"];
    dataJSON["lights"] = [light];

    return dataJSON;
}

function sendToApi(dataJSON){

    dataJSON.environment = formatJSONForBackEnd(dataJSON.environment);
    //Hardcoding light TODO: For Hitesh
    dataJSON.environment.lights = [
            {"rgbColor":{"r":0.3,"g":0.3,"b":0.3}, "intensity": 1 },
            {"position":{"x":0,"y":55,"z":95},"rgbColor":{"r":1.0,"g":0,"b":0}, "intensity": 0.5},
            {"position":{"x":50,"y":55,"z":75},"rgbColor":{"r":1.0,"g":0,"b":1.0}, "intensity": 0.4}
    ]    
    
    $.ajax({
        type: 'POST',
        url: '/api/Render',
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

module.exports = {
    sendToApi,
    formatJSONForBackEnd
}