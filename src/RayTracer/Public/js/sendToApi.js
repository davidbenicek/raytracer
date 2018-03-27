'use strict';

const $ = require('jquery');
var FileSaver = require('file-saver');

function convertRGBToDecimal(colour){
  colour.r /=255;
  colour.g /=255;
  colour.b /=255;
  return colour;
}

function formatJSONForBackEnd(dataJSON){

    dataJSON.environment.winFrame.Height = parseInt(dataJSON.environment.winFrame.Height); 
    dataJSON.environment.winFrame.Width = parseInt(dataJSON.environment.winFrame.Width); 
    
    dataJSON.environment.wallPosition = parseInt(dataJSON.environment.wallPosition); 

    //Hardcoding camera
    let camera = {
        'position' : {}
    };
    camera.position.x = parseInt(dataJSON.environment.camera.x);
    camera.position.y = parseInt(dataJSON.environment.camera.y);
    camera.position.z = parseInt(dataJSON.environment.camera.z);
    camera.lookAt = {x: 0, y: 0, z: 0};
    camera.distanceViewPlane = dataJSON.environment.camera.distanceViewPlane;
    dataJSON.environment.camera = camera;

    //Converting background colours to fractions
    dataJSON.environment.background = convertRGBToDecimal(dataJSON.environment.background);

    dataJSON.objects.map((obj) => {
      obj.color = convertRGBToDecimal(obj.color);
    });

    dataJSON.environment.lights.map((obj) => {
      obj.rgbColor = convertRGBToDecimal(obj.rgbColor);
    });

    return dataJSON;
}

function sendToApi(dataJSON){
    let backendJSON = dataJSON;
    backendJSON = formatJSONForBackEnd(backendJSON);

    fetch('/api/Render', {
      body: JSON.stringify(backendJSON),
      headers: {
        'content-type': 'application/json'
      },
      method: 'POST',
    })
    .then(function(res){
      return res.blob();
    })
    .then(function(blob) {
      console.log(blob);
      FileSaver.saveAs(blob, dataJSON.environment.fileName+'.png');
    });

}

module.exports = {
    sendToApi,
    formatJSONForBackEnd
}