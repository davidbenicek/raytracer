//on submit - get values post to backend
//on stop typing - get values and render svg

const $ = require('jquery');

const render = require('../js/render.js');
const api = require('../js/sendToApi.js');

window.harvestAndSend = function(){
    const res = exports.harvest();
    console.log(res);
    api.sendToApi(res);
}

exports.harvest = function(){
    const res = {};
    res.objects = [exports.getHarvest("object")];
    res.environment = exports.getHarvest("env");
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
    $(".form-control").focusout(function () {
        const res = exports.harvest()
        //TOOD: Add switch var for y/z 2D views
        const svg = render.convertToSvg([res.object], res.env, "y");
        $("#svg").html(svg)
    })
}
)