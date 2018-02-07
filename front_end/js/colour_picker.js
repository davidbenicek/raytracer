
const $ = require('jquery');

//reference
function hexToRgb(hex) {
    // Expand shorthand form (e.g. "03F") to full form (e.g. "0033FF")
    var shorthandRegex = /^#?([a-f\d])([a-f\d])([a-f\d])$/i;
    hex = hex.replace(shorthandRegex, function (m, r, g, b) {
        return r + r + g + g + b + b;
    });

    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}


$(document).ready(function () {
    $("#color_picker").change(function () {
        console.log('yooo');
        let hex = document.getElementById("color_picker").value;
        //console.log("hex value: " + hex);
        var cp = hexToRgb(hex);
        console.log($("#colour_r"));
        
        $("#colour_r")[0].value = cp.r;
        $("#colour_g")[0].value = cp.g;
        $("#colour_b")[0].value = cp.b;

        
    })
}
)