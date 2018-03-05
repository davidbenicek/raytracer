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
    res.light = getHarvestforLight("mainlight");
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
    for (var i = 1; i <= objectSpecClasses.length; i++) {
        const dataObj = {}; 

        //to try the below, add some lights first and then click on top view. the values should appear in console

        //only 7 objects in the light
        for (let j = 0; j < 7; j++) {
            //the below works but does not print it out how we want it to
            dataObj[$('#light'+i+' :input')[j].name] = $('#light'+i+' :input')[j].value;

            //below does not show the values as I think its because I am calling the ids and not the classes?
            //I have tried the classes way and it has not worked...
            //dataObj[$('#light'+i+' :input')[j].name] = getFormValues($(('#light'+i+' :input')[j].id).serializeArray());
            //console.log($(('#light'+i+' :input')[j].id).serializeArray());
        }
        final.push(dataObj);
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