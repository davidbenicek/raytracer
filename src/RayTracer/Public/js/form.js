const $ = require('jquery');

const api = require('../js/sendToApi.js');

// const render3D = require('../js/render3D.js');

let objectsJSON =[
];

function harvestAndSend() {
    const res = harvest();
    api.sendToApi(res);
}

function harvest() {
    const res = {};
    res.objects = [getHarvest("object")];
    res.environment = getHarvest("env");
    res.uv = getHarvest("user_view");
    return res;
}

function getHarvest(spec) {
    const objectSpecClasses = $("." + spec + "_spec");

    const object = {};
    for (var i = 0; i < objectSpecClasses.length; i++) {
        object[objectSpecClasses[i].name] = getFormValues($("#" + objectSpecClasses[i].id).serializeArray());
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
    harvestAndSend,
    harvest
}