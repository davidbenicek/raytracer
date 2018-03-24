const $ = require('jquery');
const form = require("./form.js")
const render = require("./render.js")
const drag_drop = require("./drag_drop.js")

let svgID = "";


function assignToolTip() {
    $(".svg-object").dblclick(function(e){
    console.log(e);
    svgID = e.target.id;
    //Get the position of the element we just clicked on
    let x,y;
    x = e.screenX //+ $("#svg").offset().left;
    y = e.screenY //- $("#svg").offset().top;
  
    //Move the popover
    const tooltip = $(".tooltip-box");
    tooltip.show();
    tooltip.css({top: y+'px', left: x+'px'});

    //Highlight element
    $("#"+svgID).attr('stroke','yellow');

    //Activate click-off to close
    $('.bottom-half').click(function(){
        tooltip.hide();
        $("#"+svgID).attr('stroke','none');
        svgID = "";
    });

    //Populate the popover
    for (let key in form.objectsJSON) {
      if ( (form.objectsJSON[key].id) === svgID){
        $("#size_x").val(form.objectsJSON[key].size.x);
        $("#size_y").val(form.objectsJSON[key].size.y);
        $("#size_z").val(form.objectsJSON[key].size.z);

        $("#colour_r").val(form.objectsJSON[key].color.r);
        $("#colour_g").val(form.objectsJSON[key].color.g);
        $("#colour_b").val(form.objectsJSON[key].color.b);
      }
    }
  });
  $("#objectSubmit").unbind("click");
  $("#objectSubmit").click(function(){
    //update the json and rerender
    for (let key in form.objectsJSON) {
      if ( (form.objectsJSON[key].id) === svgID){
        form.objectsJSON[key].size.x = $("#size_x").val();
        form.objectsJSON[key].size.y = $("#size_y").val();
        form.objectsJSON[key].size.z = $("#size_z").val();
        
        form.objectsJSON[key].color.r = $("#colour_r").val();
        form.objectsJSON[key].color.g = $("#colour_g").val();
        form.objectsJSON[key].color.b = $("#colour_b").val();
        
        $('.tooltip-box').hide();

        regenerateScene();
      }
    }
  });

}

function regenerateScene(){
  const view = $('input[name=chosen-view]:checked')[0].value;
  let svg;

  switch (view) {
    case "Top":
    svg = render.convertToSvg(form.objectsJSON, form.env, "z");
    $("#svg-container").html(svg);
    drag_drop.bindListeners();
    break;
  default:
    svg = render.convertToSvg(form.objectsJSON, form.env, "y");
    $("#svg-container").html(svg)
    assignToolTip();
    drag_drop.bindListeners();
    break;
  }
}

// Make a function to close the popover
function retunToolTip() {
    $("objectSubmit").click(function(){

        let x,y;
        // x = original position
        // y = original position
        
        console.log("here's the x,y,",x,y)
        //Move the popover
        $(".tooltip-box").css({top: x+'px', left: y+'px'});

  });
}


//Make a function to save the edits made in the popover


module.exports = {
  assignToolTip
}