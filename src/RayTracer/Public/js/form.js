//on submit - get values post to backend
//on stop typing - get values and render svg

const $ = require('jquery');

const render = require('../js/render.js');
const api = require('../js/sendToApi.js');
// const render3D = require('../js/render3D.js');

window.objectsJSON =[
    {"shape":"Sphere","size":{"x":30,"y":30,"z":30},"point":{"x":200,"y":300,"z":160},
    "color":{"r":0.0,"g":0.0,"b":1},"material":"flat"},
    {"shape":"Cube","size":{"x":40,"y":100,"z":40},"point":{"x":200,"y":100,"z":200},
    "color":{"r":1,"g":1,"b":1},"material":"flat"}
];

window.harvestAndSend = function () {
    const res = exports.harvest();
    api.sendToApi(res);
}

window.routeToView = function () {
    console.log("Calling route");
    const res = exports.harvest()
    const view = $('input[name=chosen-view]:checked')[0].value;
    let svg;
    switch(view) {
        case "3D":
            console.log("render3D.init(objectsJson,res.environment)");
            break;
        case "Top":
            svg = render.convertToSvg(window.objectsJSON, res.environment, "z");
            $("#svg-container").html(svg)
            break;
        default:
            svg = render.convertToSvg(window.objectsJSON, res.environment, "y");
            $("#svg-container").html(svg)
            break;
    }
}

exports.harvest = function () {
    const res = {};
    res.objects = [exports.getHarvest("object")];
    res.environment = exports.getHarvest("env");
    res.uv = exports.getHarvest("user_view");
    return res;
}

exports.getHarvest = function (spec) {
    const objectSpecClasses = $("." + spec + "_spec");

    const object = {};
    for (var i = 0; i < objectSpecClasses.length; i++) {
        object[objectSpecClasses[i].name] = exports.getFormValues($("#" + objectSpecClasses[i].id).serializeArray());
    }
    return object;

}

//TODO: Write a test for this
exports.getFormValues = function (dataArray) {
    const len = dataArray.length,
        dataObj = {};

    for (let i = 0; i < len; i++) {
        dataObj[dataArray[i].name] = dataArray[i].value;
    }
    return dataObj;
}

$(document).ready(function () {
    $(".form-control").change(window.routeToView)
    $("#view").change(window.routeToView)
    window.routeToView()
})