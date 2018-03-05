const $ = require('jquery');

$(document).ready(function () {
    $("#add").click(function () {
       
        var intId = ($('.mainlight_spec').length + 1);
        var fieldWrapper = $("<div class=\"mainlight_spec\"  id=\"light" + intId + "\"/>");
        fieldWrapper.data("idx", intId);
        var position = $("<form name=\"position\" id=\"position\" class=\"light_spec\"><label for=\"light_position\">Position</label><div class=\"form-group row\" id=\"light_position\"><div class=\"col-xs-4\"><label for=\"light_x\">x</label><input name=\"x\" class=\"form-control\" id=\"light_x\" type=\"text\" value=\"1000\"></div><div class=\"col-xs-4\"><label for=\"light_y\">y</label><input name=\"y\" class=\"form-control\" id=\"light_y\" type=\"text\" value=\"1000\"></div><div class=\"col-xs-4\"><label for=\"light_z\">z</label><input name=\"z\" class=\"form-control\" id=\"light_z\" type=\"text\" value=\"1000\"></div></div></form>");
        var color = $("<form name=\"rgbColor\" id=\"rgbColor\" class=\"light_spec\"><div class=\"form-group row\" id=\"light_color\"><div class=\"col-xs-4\"><label for=\"light_r\">R</label><input name=\"r\" class=\"form-control\" id=\"light_r\" type=\"text\" value=\"255\"></div><div class=\"col-xs-4\"><label for=\"light_g\">G</label><input name=\"g\" class=\"form-control\" id=\"light_g\" type=\"text\" value=\"255\"></div><div class=\"col-xs-4\"><label for=\"light_b\">B</label><input name=\"b\" class=\"form-control\" id=\"light_b\" type=\"text\" value=\"255\"></div></div></form>");
        var intensity = $("<form name=\"intensity\" id=\"intensity\" class=\"light_spec\"><div class=\"form-group\"><label for=\"light_intensity\">Intensity</label><input name=\"intensity\" type=\"text\" class=\"form-control\" id=\"light_intensity\" value=\"100\"></div></form>");
        var removeButton = $("<input type=\"button\" class=\"remove\" value=\"-\" />");
        removeButton.click(function () {
            $(this).parent().remove();
        });
        fieldWrapper.append(position);
        fieldWrapper.append(color);
        fieldWrapper.append(intensity);
        fieldWrapper.append(removeButton);
        $("#lights").append(fieldWrapper);
    });

});



	/* 
	"environment":
	{
		"fileName":"test",
		"winFrame":{"Width":800,"Height":600 },
		"background":{"r":0.2,"g":0.4,"b":0.4},
		"wallPosition": 100,
		"camera" : { "position":{"x":0,"y":0,"z":500}, "lookAt": {"x":-5,"y":0,"z":0}, "distanceViewPlane":850 },
		"lights":[
			{"position":{"x":0,"y":0,"z":0},"rgbColor":{"r":0.3,"g":0.3,"b":0.3}, "intensity": 1 },
			{"position":{"x":100,"y":55,"z":95},"rgbColor":{"r":1.0,"g":0,"b":0}, "intensity": 0.5},
			{"position":{"x":50,"y":55,"z":75},"rgbColor":{"r":1.0,"g":0,"b":1.0}, "intensity": 0.4}
		]
	}
} */