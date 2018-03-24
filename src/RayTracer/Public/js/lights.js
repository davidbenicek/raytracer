const $ = require('jquery');
const d3 = require('../js/render-3d.js');



$(document).ready(function () {
    $("#add").click(function () {

        var intId = ($('.mainlight_spec').length + 1);
        var fieldWrapper = $("<div class=\"mainlight_spec\"  id=\"light" + intId + "\"/>");
        fieldWrapper.data("idx", intId);
        var position = $("<form name=\"position\" id=\"position\" onchange=\"module.routeToView()\"  class=\"light_spec\"><label for=\"light_position\">Position</label><div class=\"form-group row\" id=\"light_position\"><div class=\"col-xs-4\"><label for=\"light_x\">x</label><input name=\"x\" class=\"form-control\" id=\"light_x\" type=\"text\" value=\"1000\"></div><div class=\"col-xs-4\"><label for=\"light_y\">y</label><input name=\"y\" class=\"form-control\" id=\"light_y\" type=\"text\" value=\"1000\"></div><div class=\"col-xs-4\"><label for=\"light_z\">z</label><input name=\"z\" class=\"form-control\" id=\"light_z\" type=\"text\" value=\"1000\"></div></div></form>");
        var color = $("<form name=\"rgbColor\" id=\"rgbColor\" onchange=\"module.routeToView()\" class=\"light_spec\"><div class=\"form-group row\" id=\"light_color\"><div class=\"col-xs-4\"><label for=\"light_r\">R</label><input name=\"r\" class=\"form-control\" id=\"light_r\" type=\"text\" value=\"255\"></div><div class=\"col-xs-4\"><label for=\"light_g\">G</label><input name=\"g\" class=\"form-control\" id=\"light_g\" type=\"text\" value=\"255\"></div><div class=\"col-xs-4\"><label for=\"light_b\">B</label><input name=\"b\" class=\"form-control\" id=\"light_b\" type=\"text\" value=\"255\"></div></div></form>");
        var intensity = $("<form name=\"intensity\" onchange=\"module.routeToView()\" id=\"intensity\" class=\"light_spec\"><div class=\"form-group\"><label for=\"light_intensity\">Intensity</label><input name=\"intensity\" type=\"text\" class=\"form-control\" id=\"light_intensity\" value=\"100\"></div></form>");
        var removeButton = $("<input type=\"button\"  class=\"remove\" value=\"-\" />");
        removeButton.click(function () {
            let length = ($('.mainlight_spec').length)
            if (length == 1) {
                window.alert("Cannot remove all lights. Please leave at least one light");
            } else {
                $(this).parent().remove();
            }
        });
        fieldWrapper.append(position);
        fieldWrapper.append(color);
        fieldWrapper.append(intensity);
        fieldWrapper.append(removeButton);
        $("#lights").append(fieldWrapper);
    });

});

