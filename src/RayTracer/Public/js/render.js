
const shapes =`
          <rect id="inventoryBackground" width="500" height="100" x="0" y="0"/>
          <g id="inventory">
          <circle id="curve4" class="inventory" cx="80" cy="36" r="35" />
          <rect id="curve3" class="inventory" x="150" y="0" width="60" height="60"/>
          <circle id="curve2" class="inventory" cx="280" cy="36" r="35" />
          <rect id="curve1" class="inventory" x="350" y="0" width="60" height="60"/>
          </g>    
          <g id="canvas">
          </g>
`

exports.getSVGForSphere = function (obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in<text>";
  }

  return `<circle  cx="${obj.point.x}" cy="${obj.point[dimension]}" r="${obj.size.x}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});"/>`
}

exports.getSVGForCube = function (obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in</text>";
  }

  return `<rect  x="${obj.point.x}" y="${obj.point[dimension]}" width="${obj.size.x}" height="${obj.size[dimension]}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});"/>`
}

exports.convertToSvg = function (jsonObj, env, dimension) {

  if (!jsonObj || !jsonObj.length) {
    return "No object to render";
  }
  if (!env) {
    return "No environment specified for rendering";
  }
  if (!dimension) {
    return "No dimension to render in";
  }

  try {
    console.log(env);
    let svg = `<svg id="svg1" ` +
      `width="${env.winFrame.Width}"` +
      `height="${env.winFrame.Height}"` +
      `style="fill:rgb(${env.background.r},${env.background.g},${env.background.b});"` +
      `>`
    svg += jsonObj.map((obj) => {
      //TODO: This is wrong, we need shape just once not twice - object too deep
      //does this matter? if it does then its to do with the .serialisearray in getHarvest - form.js
      switch (obj.shape.shape) {
        case "Sphere":
          return exports.getSVGForSphere(obj, dimension);
        case "Cube":
          return exports.getSVGForCube(obj, dimension);
        default:
          return "<text x=20 y=20>Object type not supported</text>";
      }
    }).join('')

    svg += shapes;

    svg += "</svg>";
    console.log(svg);
    return svg;

  } catch (err) {
    console.log(err);
    return "You have not specified the object in the correct format";
  }
}
