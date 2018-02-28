const $ = require('jquery');

function assignToolTip() {
  $('.svg-object').dblclick(function(e){
    console.log(e);
    console.log("here's the id",e.target.id)
    //Get the position of the element we just clicked on
    let x,y;
    x = e.offsetX + $("#svg").offset().left;
    y = e.offsetY-  $("#svg").offset().top;
    
    console.log("here's the x,y,",x,y)
    //Move the popover
    $("#popover").css({top: x, left: x, position:'absolute'});
    $("#someobject)
    //Populate the popover

  })
}


//Make a function to close the popover

//Make a function to save the edits made in the popover


module.exports = {
  assignToolTip
}