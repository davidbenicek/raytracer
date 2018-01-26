
exports.getSVGForSphere = function (obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in<text>";
  }

  return `<circle cx="${obj.point.x}" cy="${obj.point[dimension]}" r="${obj.size.x}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});" />`
}

exports.getSVGForCube = function (obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in</text>";
  }

  return `<rect x="${obj.point.x}" y="${obj.point[dimension]}" width="${obj.size.x}" height="${obj.size[dimension]}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});" />`
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

    let svg = `<svg ` +
      `width="${env.scene_size.x}"` +
      `height="${env.scene_size.y}"` +
      `style="fill:rgb(${env.background.r},${env.background.g},${env.background.b});"` +
      `>`

    svg += jsonObj.map((obj) => {
      switch (obj.type) {
        case "sphere":
          return exports.getSVGForSphere(obj, dimension);
        case "cube":
          return exports.getSVGForCube(obj, dimension);
        default:
          return "<text x=20 y=20>Object type not supported</text>";
      }
    }).join('')

    svg += "</svg>";
    return svg;

  } catch (err) {
    return "You have not specified the object in the correct format";
  }
}
