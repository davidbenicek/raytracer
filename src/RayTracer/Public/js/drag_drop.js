'use strict';

const $ = require('jquery');

const form = require("./form.js")

//Keeps id of generic created objs
let count = 0;

//Exported for testing
let new_object = "";
let dragged_id = "";

//Triggered on mouse down
function startObjectDrag(shape){

  const id = "object"+(count++);

  dragged_id = id;
  module.exports.dragged_id = dragged_id;
  new_object = shape;
  module.exports.new_object = new_object;

  
}

//Triggered on drag end
function clearObjectDrag(){

  dragged_id = "";
  module.exports.dragged_id = dragged_id;
  new_object = "";
  module.exports.new_object = new_object;
  
}

function showObjectDrag(){
  let entrant;
  //If we are dragging in a new object
  if(dragged_id != "" && new_object != ""){
    //Monitor movement within #svg element
    $("#svg").mousemove(function(e) {
      //Calculating relative position within #svg by getting cursor pos and taking away top right corner of #svg
      const dimension = ($('input[name=chosen-view]:checked')[0].value) == "Side" ? "y" : "z"
      
      let x_new = e.pageX - $("#svg").position().left;
      let yz_new = e.pageY - $("#svg").position().top;

      let x_json = convertSVGCordsToJSON(x_new,"x");
      let yz_json = convertSVGCordsToJSON(yz_new,dimension);
      
      //Create the default SVG shape
      entrant = createDefaultShape(new_object,dragged_id,x_new,yz_new);
      //Add it to the actual #svg element
      entrant.appendTo($("#svg"));
      //Also update JSON
      addToJSON(new_object,dragged_id,x_json,yz_json);
      //Now that we are inside the SVG and not dragging a new object in, we want to replace the mouse move listener
      $("#svg").unbind("mousemove");
      
      bindListeners();
      //Trigger movement of the element we just moved in
      $("#"+dragged_id).trigger("mousedown");
      //This object is no loger new
      new_object = "";
    });

  }
  
}

function bindListeners(){
  $(".svg-object").mousedown(function(e){
    dragged_id = e.target.id;
    //Have to disable pointer events and all objects except for the one I am dragging
    //this is because if I drag the target object over an object that is rendered above it, the focus of the event changes!
    $(".svg-object").not(e.target).css( 'pointer-events', 'none' );
    $("#svg").mousemove(function(e){
      if(e.target.id != dragged_id){
        $(".svg-object").trigger("mouseup");
      }

      const dimension = ($('input[name=chosen-view]:checked')[0].value) == "Side" ? "y" : "z"


      //Calculate position of the cursor in reference to the SVG
      let x_new = e.pageX - $("#svg").position().left;
      let yz_new = e.pageY - $("#svg").position().top;

      let x_json = convertSVGCordsToJSON(x_new,"x");
      let yz_json = convertSVGCordsToJSON(yz_new,dimension);
      //Update in JSON
      updateJSONWithMove(e.target.id,dimension,x_json,yz_json);
      //Move object in SVG
      if(e.target.tagName == "rect")
        moveRect(e.target,x_new,yz_new);
      else
        moveCircle(e.target,x_new,yz_new);
    })
  })

  $(".svg-object").mouseup(function(){
    //Re-enable pointer events
    $(".svg-object").css( 'pointer-events', 'auto' );
    //Stop tracking the mouse movements
    $("#svg").unbind("mousemove");
    dragged_id = "";
  })
  
}

function findObjectInJSON(id){
  for(let i in form.objectsJSON){
    if(form.objectsJSON[i].id == id){
      return i;
    }
  }
  return -1;
}
/*We take the last value to be both y and z, 
the reason for this is that method is used to create the object in the SVG when it's dragged in initially. 
The 'drag in' always happens in one of the 2D views so you never know both the Z and the Y - always just one at a time. 
Therefore, we set the value of z and y to be wherever the cursor entered the svg and then we update the position as the user drags the object around in the 2D views */
function addToJSON(shape,id,x,yz){
  if(findObjectInJSON(id) == -1){
    let shape_name = "";
    switch (shape){
      case "rect":
        shape_name = "cube"
        break;
      default:
        shape_name = "sphere"
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
    form.objectsJSON.push(obj)
  }
}

function updateJSONWithMove(id,dimension,x,yz){
  const i = findObjectInJSON(id);
  if(i != -1){
    form.objectsJSON[i].point.x = x;
    form.objectsJSON[i].point[dimension] = yz;
  }
}

function convertSVGCordsToJSON(value,dimension) {
  if(dimension == "x")
    return value - parseInt(form.env.winFrame.Width)/2;
  else 
    return value - parseInt(form.env.winFrame.Height)/2
}

function moveCircle(target,x,yz){
  $(target).attr("cx",x).attr("cy",yz);
}

function moveRect(target,x,yz){
  x -= target.width.baseVal.value/2
  yz -= target.height.baseVal.value/2
  $(target).attr("x",x).attr("y",yz);
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
      .attr('r', 35)
      .attr('class','svg-object')
      .attr('id', id)
  }
}

module.exports = {
  dragged_id,
  new_object,
  bindListeners,
  showObjectDrag,
  startObjectDrag,
  clearObjectDrag,
  findObjectInJSON,
  addToJSON,
  updateJSONWithMove,
  createDefaultShape,
  convertSVGCordsToJSON
} 
