//on submit - get values post to backend
//on stop typing - get values and render svg

const $ = require('jquery');

const render = require('../js/render.js');
const api = require('../js/sendToApi.js');
const d3 = require('../js/render-3d.js');

let objectsJson =
    [
        {"shape":"Sphere","size":{"x":30,"y":30,"z":30},"point":{"x":0,"y":0,"z":0},
        "color":{"r":0,"g":0,"b":255},"material":"flat"},
        {"shape":"Cube","size":{"x":100,"y":100,"z":100},"point":{"x":100,"y":200,"z":300},
        "color":{"r":138,"g":43,"b":226},"material":"flat"}
    ]
;

window.harvestAndSend = function () {
    const res = exports.harvest();
    api.sendToApi(res);
}

window.routeToView = function () {
    console.log("Calling route");
    let res = exports.harvest()
    const view = $('input[name=chosen-view]:checked')[0].value;
    let svg;
    switch(view) {
        case "3D":
            //TODO: fix css 
            $( "#ThreeJS" ).empty();
            $(".2d-views").hide();
            //$("#environment-input").hide();
            $("#ThreeJS").show();
            d3.init(res.environment.background,res.environment.camera,res.environment.position);
            d3.animate();
            d3.jsonToShape(objectsJson);
            break;
        case "Top":
            $( "#ThreeJS" ).empty();
            $(".2d-views").show();
            $("#svg-container").show();
            $("#environment-input").show();
            $("#ThreeJS").hide();
            svg = render.convertToSvg(objectsJson, res.environment, "z");
            $("#svg-container").html(svg)
            break;
        default:
            $( "#ThreeJS" ).empty();
            $(".2d-views").show();
            $("#svg-container").show();
            $("#environment-input").show();
            $("#ThreeJS").hide();
            svg = render.convertToSvg(objectsJson, res.environment, "y");
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