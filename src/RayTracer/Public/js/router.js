'use strict';

const $ = require('jquery');

const form = require("./form.js")
const drag_drop = require("./drag_drop.js")
const render = require('../js/render.js');
const d3 = require('../js/render-3d.js');

function routeToView() {
    const res = form.harvest()
    const view = $('input[name=chosen-view]:checked')[0].value;
    let svg;
    switch(view) {
        case "3D":
            $( "#ThreeJS" ).empty();
            $(".2d-views").hide();
            $("#ThreeJS").show();
            d3.init(res.environment.background,res.environment.camera,res.environment.position);
            d3.animate();
            d3.jsonToShape(form.objectsJSON);
            break;
        case "Top":
            $( "#ThreeJS" ).empty();
            $(".2d-views").show();
            $("#svg-container").show();
            $("#ThreeJS").hide();
            svg = render.convertToSvg(form.objectsJSON, res.environment, "z");
            $("#svg-container").html(svg)
            drag_drop.bindListeners()
            break;
        default:
            $( "#ThreeJS" ).empty();
            $(".2d-views").show();
            $("#svg-container").show();
            $("#ThreeJS").hide();
            svg = render.convertToSvg(form.objectsJSON, res.environment, "y");
            $("#svg-container").html(svg)
            drag_drop.bindListeners()
            break;
    }
}

$(document).ready(function () {
  $(".form-control").change(routeToView)
  $("#view").change(routeToView)
  routeToView()
})

module.exports = {
    routeToView
}