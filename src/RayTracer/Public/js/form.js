const $ = require('jquery');

const api = require('../js/sendToApi.js');
const d3 = require('../js/render-3d.js');

let objectsJSON =[
    {"shape":"Sphere","id":"object0","size":{"x":30,"y":30,"z":30},"point":{"x":0,"y":0,"z":0},
    "color":{"r":0.0,"g":0.0,"b":1},"material":"flat"},
    {"shape":"Cube","id":"object1","size":{"x":40,"y":100,"z":40},"point":{"x":200,"y":100,"z":200},
    "color":{"r":1,"g":1,"b":1},"material":"flat"}
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
    res.objects = [getHarvest("object")];
    res.environment = getHarvest("env");
    env = res.environment;
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
    env,
    harvestAndSend,
    harvest
}