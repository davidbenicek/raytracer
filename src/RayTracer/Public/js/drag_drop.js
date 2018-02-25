const $ = require('jquery');

const form = require("./form.js")

//Keeps id of generic created objs
let count = 0;

//Exported for testing
module.exports.new_object = "";
module.exports.dragged_id = "";

//Triggered on mouse down
function startObjectDrag(shape){

  const id = "object"+(count++);

  module.exports.dragged_id = id;
  module.exports.new_object = shape;
  
}

//Triggered on drag end
function clearObjectDrag(){

  module.exports.dragged_id = "";
  module.exports.new_object = "";
  
}

function showObjectDrag(){
  let entrant;
  //If we are dragging in a new object
  if(module.exports.dragged_id != "" && module.exports.new_object != ""){
    //Monitor movement within #svg element
    $("#svg").mousemove(function(e) {
      //Calculating relative position within #svg by getting cursor pos and taking away top right corner of #svg
      let x_new = e.pageX - $("#svg").position().left;
      let y_new = e.pageY - $("#svg").position().top;
      
      //Create the default SVG shape
      entrant = createDefaultShape(module.exports.new_object,module.exports.dragged_id,x_new,y_new);
      //Add it to the actual #svg element
      entrant.appendTo($("#svg"));
      //Also update JSON
      addToJSON(module.exports.new_object,module.exports.dragged_id,x_new,y_new);
      //Now that we are inside the SVG and not dragging a new object in, we want to replace the mouse move listener
      $("#svg").unbind("mousemove");
      
      bindListeners();
      //Trigger movement of the element we just moved in
      $("#"+module.exports.dragged_id).trigger("mousedown");
      //This object is no loger new
      module.exports.new_object = "";
    });

  }
  
}

function bindListeners(){
  $(".svg-object").mousedown(function(e){
    module.exports.dragged_id = e.target.id;
    //Have to disable pointer events and all objects except for the one I am dragging
    //this is because if I drag the target object over an object that is rendered above it, the focus of the event changes!
    $(".svg-object").not(e.target).css( 'pointer-events', 'none' );
    $("#svg").mousemove(function(e){
      if(e.target.id != module.exports.dragged_id){
        $(".svg-object").trigger("mouseup");
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
    //Re-enable pointer events
    $(".svg-object").css( 'pointer-events', 'auto' );
    //Stop tracking the mouse movements
    $("#svg").unbind("mousemove");
    module.exports.dragged_id = "";
  })
  
}

function findObjectInJSON(id){
  for(i in form.objectsJSON){
    if(form.objectsJSON[i].id == id){
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
      .attr('r', 45)
      .attr('class','svg-object')
      .attr('id', id)
  }
}

module.exports = {
  bindListeners,
  showObjectDrag,
  startObjectDrag,
  clearObjectDrag,
  findObjectInJSON,
  addToJSON,
  updateJSONWithMove,
  createDefaultShape
} 