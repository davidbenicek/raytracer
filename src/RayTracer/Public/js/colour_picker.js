
const $ = require('jquery');

const form = require('../js/form.js');

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

function rgbToHex(r,g,b){
    return "#"+(1<<24|r<<16|g<<8|b).toString(16).slice(1)
}

function changeColourPickerValue(){
    const red = $("#colour_r")[0].value;
    const green = $("#colour_g")[0].value;
    const blue = $("#colour_b")[0].value;
    const hex = rgbToHex(red,green,blue);
    console.log(hex);
    document.getElementById("color_picker").value = hex;
}


$(document).ready(function () {
    $("#color_picker").change(function () {
        const hex = document.getElementById("color_picker").value;
        var cp = hexToRgb(hex);        
        
        $("#colour_r")[0].value = cp.r;
        $("#colour_g")[0].value = cp.g;
        $("#colour_b")[0].value = cp.b;
        
        form.renderSvg();        
    })
    
    changeColourPickerValue()
    $("#colour_r, #colour_g, #colour_b").keyup(changeColourPickerValue)
}
)