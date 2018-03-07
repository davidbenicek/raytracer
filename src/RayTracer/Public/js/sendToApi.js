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


    return dataJSON;
}

function sendToApi(dataJSON){
    
    dataJSON.environment = formatJSONForBackEnd(dataJSON.environment);
    
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