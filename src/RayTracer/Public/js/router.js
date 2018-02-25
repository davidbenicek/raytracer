const $ = require('jquery');

const form = require("./form.js")
const drag_drop = require("./drag_drop.js")
const render = require('../js/render.js');

function routeToView() {
    const res = form.harvest()
    const view = $('input[name=chosen-view]:checked')[0].value;
    let svg;
    switch(view) {
        case "3D":
            console.log("render3D.init(objectsJson,res.environment)");
            break;
        case "Top":
            svg = render.convertToSvg(form.objectsJSON, res.environment, "z");
            $("#svg-container").html(svg)
            drag_drop.bindListeners()
            break;
        default:
            svg = render.convertToSvg(form.objectsJSON, res.environment, "y");
            $("#svg-container").html(svg)
            drag_drop.bindListeners(); 
            break;
    }
}

$(document).ready(function () {
  $(".form-control").change(routeToView)
  $("#view").change(routeToView)
  routeToView()
})