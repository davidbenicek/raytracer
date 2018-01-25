
const objs = [{
  "type": "sphere",
  "size": { "x": 35, "y": 50, "z": 50 },
  "color": { "r": 0, "g": 100, "b": 0 },
  "material": "metal"
}, {
  "type": "cube",
  "size": { "x": 250, "y": 500, "z": 50 },
  "point": { "x": 400, "y": 400, "z": 400 },
  "color": { "r": 100, "g": 0, "b": 0 },
  "material": "metal"
}]

const envz = {
  "fileName": "render.png",
  "scene_size": { "x": 500, "y": 500 },
  "background": { "r": 255, "g": 0, "b": 0 }
}

exports.getSVGForSphere = function (obj, dimension) {
  
  if(!obj || obj.length){
    return "No object to render";
  }
  if(!dimension){
    return "No dimension to render in";
  }

  return `<circle cx="${obj.point.x}" cy="${obj.point[dimension]}" r="${obj.size.x}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});" />`
}

exports.getSVGForCube = function (obj, dimension) {

  if(!obj || !obj.length){
    return "No object to render";
  }
  if(!dimension){
    return "No dimension to render in";
  }
  try {
    return `<rect x="${obj.point.x}" y="${obj.point[dimension]}" width="${obj.size.x}" height="${obj.size[dimension]}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});" />`
  }
  catch(err){
    throw "You have not specified the object in the correct format"
  }
}

exports.convertToSvg = function (jsonObj, env, dimension) {

  if(!jsonObj || !jsonObj.length){
    return "No object to render";
  }
  if(!env){
    return "No environment specified for rendering";
  }
  if(!dimension){
    return "No dimension to render in";
  }

  try {

    let svg = `<svg `+
      `width="${env.scene_size.x}"`+
      `height="${env.scene_size.y}"`+
      `style="fill:rgb(${env.background.r},${env.background.g},${env.background.b});"`+
    `>`
  
    svg += jsonObj.map((obj) => {
      switch (obj.type) {
        case "sphere":
          return exports.getSVGForSphere(obj, dimension);
        case "cube":
          return exports.getSVGForCube(obj, dimension);
        default:
          return "Object type not supported";
      }
    })
  
    svg += "</svg>";
    return svg;

  }catch(err){
    return "You have not specified the object in the correct format";
  }
}

console.log(exports.convertToSvg(objs, envz, "z"));