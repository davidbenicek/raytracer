'use strict';

const $ = require('jquery');

const api = require('../js/sendToApi.js');
const d3 = require('../js/render-3d.js');

let objectsJSON =[];

let env = {
  "wallPosition": "500",
};

function harvestAndSend() {
    const res = harvest();
    api.sendToApi(res);
}

function harvest() {
    const res = {};
    res.objects = objectsJSON;
    res.environment = getHarvest("env");
    res.environment.lights = getHarvestforLight("light");
    env = res.environment;
    module.exports.env = env;
    return res;
}

function getHarvest(spec) {
    const objectSpecClasses = $("." + spec + "_spec");

    const object = {};
    for (var i = 0; i < objectSpecClasses.length; i++) {
        let res = getFormValues($("#" + objectSpecClasses[i].id).serializeArray());
        if(objectSpecClasses[i].id in res)
            res = res[objectSpecClasses[i].id];
        object[objectSpecClasses[i].name] = res;
    }
    return object;

}

function getHarvestforLight(spec) {
    const objectSpecClasses = $("." + spec + "_spec");
    //the above calls the class(mainlight_spec) in which the forms are put in for position,colour,intensity
    //each form has a different id:light1, light2... but they all have the same class(mainlight_spec)
    const final = [];
    //checks the number of lights created
    let object = {};
    for (var i = 0; i < objectSpecClasses.length; i++) {
        let res = getFormValues($(objectSpecClasses[i]).serializeArray());
        if(objectSpecClasses[i].id in res)
          res = res[objectSpecClasses[i].id];
        object[objectSpecClasses[i].name] = res;
        if((i+1) % 3 == 0){
            final.push(object);
            object = {};
        }
    }
    return final;
}

//TODO: Write a test for this
function getFormValues(dataArray) {
    const len = dataArray.length,
        dataObj = {};

    for (let i = 0; i < len; i++) {
        dataObj[dataArray[i].name] = dataArray[i].value;
    }
    return dataObj;
}

module.exports = {
    objectsJSON,
    env,
    harvestAndSend,
    harvest
}

