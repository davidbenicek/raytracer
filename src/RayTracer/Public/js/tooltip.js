const $ = require('jquery');
const form = require("./form.js")

function assignToolTip() {
    $(".svg-object").dblclick(function(e){
    console.log(e);
    console.log("here's the id",e.target.id)
    //Get the position of the element we just clicked on
    let x,y;
    x = e.offsetX + $("#svg").offset().left;
    y = e.offsetY-  $("#svg").offset().top;
    
    console.log("here's the x,y,",x,y)
    //Move the popover
    var c = $(".popover-markup")
    c.show();
    $(".popover-markup").css({top: y+'px', left: x+'px'});
    // $("#someobject)


    //Populate the popover
    let svgID = e.target.id; 


    for (var key in form.objectsJSON) {

      if ( (form.objectsJSON[key].id) === svgID){

        // console.log(form.objectsJSON[key].size);

        $("#size_x").val(form.objectsJSON[key].size.x);
        $("#size_y").val(form.objectsJSON[key].size.y);
        $("#size_x").val(form.objectsJSON[key].size.z);

      }
    }


  })
}

$("#id of submitt button").click(function(){
  //update the json and rerender

  for (var key in form.objectsJSON) {

    if ( (form.objectsJSON[key].id) === svgID){

      // console.log(form.objectsJSON[key].size);

      

    }

  }

});

// Make a function to close the popover
function retunToolTip() {
    $("objectSubmit").click(function(){

        let x,y;
        // x = original position
        // y = original position
        
        console.log("here's the x,y,",x,y)
        //Move the popover
        $(".popover-markup").css({top: x+'px', left: y+'px'});

  })
}


//Make a function to save the edits made in the popover


module.exports = {
  assignToolTip
}