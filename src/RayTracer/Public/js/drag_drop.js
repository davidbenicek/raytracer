const $ = require('jquery');

const form = require('../js/form.js');

let count = 0;
let new_object = "";
let dragged_id = "";


// $(document).ready(function() {

//   console.log("yolo");
  
// });

window.startObjectDrag = function(shape){
  console.log("mouse drag!")

  const id = "object"+(count++);

  dragged_id = id;
  new_object = shape;
  
}

window.clearObjectDrag = function(){

  dragged_id = "";
  new_object = "";
  
}

window.showObjectDrag = function(){
  console.log("mouse enter!")
  let entrant;
  console.log(this.e);
  if(dragged_id != "" && new_object != ""){
    console.log(new_object)

    $("#svg").mousemove(function(e) {
      let x_new = e.pageX - $("#svg").position().left;
      let y_new = e.pageY - $("#svg").position().top;
      
      entrant = createDefaultShape(new_object,dragged_id,x_new,y_new);
      entrant.appendTo($("#svg"));
      addToJSON(new_object,dragged_id,x_new,y_new);
      $("#svg").unbind("mousemove");

      bindListeners();

      $("#"+dragged_id).trigger("mousedown");
      new_object = "";
    });

  }
  
}

function bindListeners(){
  $(".svg-object").mousedown(function(e){
    dragged_id = e.target.id;
    //Have to disable pointer events and all objects except for the one I am dragging
    //this is because if I drag the target object over an object that is rendered above it the focus of the even changes!
    $(".svg-object").not(e.target).css( 'pointer-events', 'none' );
    $("#svg").mousemove(function(e){
      if(e.target.id != dragged_id){
        console.log(e.target.id , dragged_id)
        console.log("LOST IT!");
        $("#"+dragged_id).trigger("mouseup");
      }

      //Calculate position of the cursor in reference to the SVG
      let x_new = e.pageX - $("#svg").position().left;
      let y_new = e.pageY - $("#svg").position().top;

      //Update in JSON
      updateJSONWithMove(e.target.id,"y",x_new,y_new);
      //Move object in SVG
      if(e.target.tagName == "rect")
        moveRect(e.target,x_new,y_new);
      else
        moveCircle(e.target,x_new,y_new);
    })
  })
  $(".svg-object").mouseup(function(){
    console.log("UP",dragged_id);
    //Re-enable pointer events
    $(".svg-object").css( 'pointer-events', 'auto' );
    //Stop tracking the mouse movements
    $("#svg").unbind("mousemove");
    dragged_id = "";
  })
}

function findObjectInJSON(id){
  for(i in window.objectsJSON){
    if(window.objectsJSON[i].id == id){
      console.log("Object ",id," exists")
      return i;
    }
  }
  return -1;
}

function addToJSON(shape,id,x,yz){
  if(findObjectInJSON(id) == -1){
    let shape_name = "";
    switch (shape){
      case "rect":
        shape_name = "Cube"
        break;
      default:
        shape_name = "Sphere"
        break;
    }

    const obj = {
      "shape": shape_name,
      "id" : id,
      "size":{"x":70,"y":70,"z":70},
      "point":{"x":x,"y":yz,"z":yz},
      "color":{"r":0.0,"g":0.0,"b": 0.0},
      "material":"flat"
    };
    console.log("ADD",obj)
    window.objectsJSON.push(obj)
  }
}

function updateJSONWithMove(id,dimension,x,yz){
  const i = findObjectInJSON(id);
  if(i != -1){
    window.objectsJSON[i].point.x = x;
    window.objectsJSON[i].point[dimension] = yz;
  }
}

function moveCircle(target,x,y){
  $(target).attr("cx",x).attr("cy",y);
}

function moveRect(target,x,y){
  x -= target.width.baseVal.value/2
  y -= target.height.baseVal.value/2
  $(target).attr("x",x).attr("y",y);
}

function createDefaultShape(shape,id,pos_x,pos_yz){
  let svg = document.createElementNS('http://www.w3.org/2000/svg', shape)
  switch(shape) {
    case "rect":
      pos_x -= 35;
      pos_yz -= 35;
      return $(svg).attr('x', pos_x)
      .attr('y', pos_yz)
      .attr('width', 70)
      .attr('height', 70)
      .attr('class','svg-object')
      .attr('id', id)
    default:
      return $(svg).attr('cx', pos_x)
      .attr('cy', pos_yz)
      .attr('r', 45)
      .attr('class','svg-object')
      .attr('id', id)
  }
}


module.exports = {
  bindListeners
}