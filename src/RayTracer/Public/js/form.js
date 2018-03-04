'use strict';

const $ = require('jquery');

const api = require('../js/sendToApi.js');
const d3 = require('../js/render-3d.js');

let objectsJSON =[
];

let env = {
    "winFrame":{"Width":500,"Height":500 }
};

function harvestAndSend() {
    const res = harvest();
    api.sendToApi(res);
}

function harvest() {
    const res = {};
    res.objects = objectsJSON;
    res.environment = getHarvest("env");
    env = res.environment;
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