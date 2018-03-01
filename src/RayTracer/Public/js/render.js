
exports.getSVGForSphere = function (obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in<text>";
  }
  return `<circle id="${obj.id}" class="svg-object" cx="${obj.point.x}" cy="${obj.point[dimension]}" r="${obj.size.x}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});"/>`
}

exports.getSVGForCube = function (obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in</text>";
  }

  return `<rect id="${obj.id}" class="svg-object" x="${obj.point.x}" y="${obj.point[dimension]}" width="${obj.size.x}" height="${obj.size[dimension]}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});"/>`
}

exports.convertToSvg = function (jsonObj, env, dimension) {

  if (!env) {
    return "No environment specified for rendering";
  }
  if (!dimension) {
    return "No dimension to render in";
  }

  try {
    let svg = `<svg id="svg"` +
      `onmouseenter="module.showObjectDrag()" ` +
      `width="${env.winFrame.Width}"` +
      `height="${env.winFrame.Height}"` +
      `style="fill:rgb(${env.background.r},${env.background.g},${env.background.b});"` +
      `>`
    if (jsonObj && jsonObj.length > 0) 
      svg += jsonObj.map((obj) => {
        switch (obj.shape) {
          case "Sphere":
            return exports.getSVGForSphere(obj, dimension);
          case "Cube":
            return exports.getSVGForCube(obj, dimension);
          default:
            return "<text x=20 y=20>Object type not supported</text>";
        }
      }).join('')

    svg += "</svg>";
    return svg;

  } catch (err) {
    console.log(err);
    return "You have not specified the object in the correct format";
  }
}
