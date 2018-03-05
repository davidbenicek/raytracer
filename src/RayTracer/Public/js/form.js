const $ = require('jquery');

const api = require('../js/sendToApi.js');
const d3 = require('../js/render-3d.js');

let objectsJSON =
    [
        {
            "shape": "Sphere", "size": { "x": 30, "y": 30, "z": 30 }, "point": { "x": 0, "y": 0, "z": 0 },
            "color": { "r": 0, "g": 0, "b": 255 }, "material": "flat"
        },
        {
            "shape": "Cube", "size": { "x": 100, "y": 100, "z": 100 }, "point": { "x": 100, "y": 200, "z": 300 },
            "color": { "r": 138, "g": 43, "b": 226 }, "material": "flat"
        }
    ]
    ;

function harvestAndSend() {
    const res = harvest();
    api.sendToApi(res);
}

function harvest() {
    const res = {};
    res.objects = [getHarvest("object")];
    res.environment = getHarvest("env");
    res.uv = getHarvest("user_view");
    res.light = getHarvestforLight("light");
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

function getHarvestforLight(spec) {
    const objectSpecClasses = $("." + spec + "_spec");
    //the above calls the class(mainlight_spec) in which the forms are put in for position,colour,intensity
    //each form has a different id:light1, light2... but they all have the same class(mainlight_spec)
    const final = [];
    //checks the number of lights created
    let object = {};
    for (var i = 0; i < objectSpecClasses.length; i++) {
    
        object[objectSpecClasses[i].name] = getFormValues($(objectSpecClasses[i]).serializeArray());
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
    harvestAndSend,
    harvest
}

//$(".light_spec").serializeArray()