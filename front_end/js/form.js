//on submit - get values post to backend
//on stop typing - get values and render svg

const $ = require('jquery');

const render = require('../js/render.js');
const cp = require('../js/colour_picker.js');

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

function renderSvg(){
    let res = {};
        res.object = exports.getHarvest("object");
        res.env = exports.getHarvest("env");
        res.uv = exports.getHarvest("user_view");

        //console.log(res.uv.user_view.view);

        if (res.uv.user_view.view == "Side View") {
            const svg = render.convertToSvg([res.object], res.env, "y");
            $("#svg").html(svg)
            console.log("Side view");
        }
        if (res.uv.user_view.view == "Top Down") {
            const svg = render.convertToSvg([res.object], res.env, "z");
            $("#svg").html(svg)
            console.log("Top view");
        }
}
$(document).ready(function () {
    $(".form-control").keyup(renderSvg)
    renderSvg();
})