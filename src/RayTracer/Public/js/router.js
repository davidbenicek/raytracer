'use strict';

const $ = require('jquery');

const form = require("./form.js")
const drag_drop = require("./drag_drop.js")
const render = require('../js/render.js');
const d3 = require('../js/render-3d.js');
const color_picker = require('../js/color_picker.js');

function routeToView() {
    const res = form.harvest();
    const view = $('input[name=chosen-view]:checked')[0].value;
    let svg;

    switch (view) {
        case "3D":
            if (res.environment.lights.length == 0) {
                window.alert("Please add some lights and try again.");
                $('#3D').removeClass('active');
                $('#Side').click();
                $('#3D').removeClass('active focus');
                break;
            }
            else {
                $("#ThreeJS").empty();
                $(".2d-views").hide();
                $("#ThreeJS").show();
                d3.init(res.environment);
                d3.addLights(res.environment.lights);
                d3.animate();
                d3.jsonToShape(form.objectsJSON);
                break;
            }
        case "Top":
            $("#ThreeJS").empty();
            $(".2d-views").show();
            $("#svg-container").show();
            $("#ThreeJS").hide();
            svg = render.convertToSvg(form.objectsJSON, res.environment, "z");
            $("#svg-container").html(svg);
            drag_drop.bindListeners();
            color_picker.initialiseColourPickerListener();
            break;
        default:
            $("#ThreeJS").empty();
            $(".2d-views").show();
            $("#svg-container").show();
            $("#ThreeJS").hide();
            svg = render.convertToSvg(form.objectsJSON, res.environment, "y");
            $("#svg-container").html(svg)
            drag_drop.bindListeners();
            color_picker.initialiseColourPickerListener();
            break;
    }
}

$(document).ready(function () {
    $(".form-control").change(routeToView)
    $("#view").change(routeToView)
    routeToView();
})

module.exports = {
    routeToView
}