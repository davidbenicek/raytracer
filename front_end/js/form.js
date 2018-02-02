//on submit - get values post to backend
//on stop typing - get values and render svg

const $ = require('jquery');

const render = require('../js/render.js');

exports.getHarvest = function (spec) {

    const objectSpecClasses = $("." + spec + "_spec");

    let object = {}
    for (var i = 0; i < objectSpecClasses.length; i++) {
        object[objectSpecClasses[i].name] = exports.getFormValues($("#" + objectSpecClasses[i].id).serializeArray());
    }
    return object;

}

//TODO: Write a test for this
exports.getFormValues = function (dataArray) {
    let len = dataArray.length,
        dataObj = {};

    for (i = 0; i < len; i++) {
        dataObj[dataArray[i].name] = dataArray[i].value;
    }
    return dataObj;
}

$(document).ready(function () {
    $(".form-control").focusout(function () {
        let res = {};
        res.object = exports.getHarvest("object");
        res.env = exports.getHarvest("env");
        //TOOD: Add switch var for y/z 2D views
        const svg = render.convertToSvg([res.object], res.env, "y");
        $("#svg").html(svg)
    })
}
)