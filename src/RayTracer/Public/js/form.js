//on submit - get values post to backend
//on stop typing - get values and render svg

const $ = require('jquery');

const render = require('../js/render.js');
const api = require('../js/sendToApi.js');


window.harvestAndSend = function () {
    const res = exports.harvest();
    api.sendToApi(res);
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

exports.renderSvg = function() {
    const res = exports.harvest()

    if (res.uv.user_view.view == "Side View") {
        const svg = render.convertToSvg(res.objects, res.environment, "y");
        $("#svg").html(svg)
    }
    if (res.uv.user_view.view == "Top Down") {
        const svg = render.convertToSvg(res.objects, res.environment, "z");
        $("#svg").html(svg)
    }
}
$(document).ready(function () {
    $(".form-control").change(exports.renderSvg)
    $("#view").change(exports.renderSvg)
    exports.renderSvg();
})