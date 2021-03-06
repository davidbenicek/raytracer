'use strict';
const form = require("./form.js")

function getSVGForSphere(obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in<text>";
  }

  const x = convertJSONCordsToSVG(obj.point.x,"x");
  const y = convertJSONCordsToSVG(obj.point[dimension],dimension);

  return `<circle id="${obj.id}" class="svg-object" cx="${x}" cy="${y}" r="${obj.size.x}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});"/>`;
}

function getSVGForCube(obj, dimension) {

  if (!obj) {
    return "<text x=20 y=20>No object to render</text>";
  }
  if (!dimension) {
    return "<text x=20 y=20>No dimension to render in</text>";
  }

  let x = convertJSONCordsToSVG(obj.point.x,"x");
  let y = convertJSONCordsToSVG(obj.point[dimension],dimension);
  x -= obj.size.x/2
  y -= obj.size[dimension]/2

  return `<rect id="${obj.id}" class="svg-object" x="${x}" y="${y}" width="${obj.size.x}" height="${obj.size[dimension]}" style="fill:rgb(${obj.color.r},${obj.color.g},${obj.color.b});"/>`
}

function convertJSONCordsToSVG(value,dimension) {
  if(dimension == "x")
    return value + parseInt(form.env.wallPosition)/2;
  else 
    return value + parseInt(form.env.wallPosition)/2;
}

function convertToSvg(jsonObj, env, dimension) {

  if (!env) {
    return "No environment specified for rendering";
  }
  if (!dimension) {
    return "No dimension to render in";
  }

  try {
    let svg = `<svg id="svg" ` +
      `onmouseenter="module.showObjectDrag()" ` +
      `width="${env.wallPosition}" ` +
      `height="${env.wallPosition}" ` +
      `style="background:rgb(${env.background.r},${env.background.g},${env.background.b});"` +
      `>`;
    if (jsonObj && jsonObj.length > 0) 
      svg += jsonObj.map((obj) => {
        switch (obj.shape) {
          case "sphere":
            return getSVGForSphere(obj, dimension);
          case "cube":
            return getSVGForCube(obj, dimension);
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

module.exports = {
  getSVGForSphere,
  getSVGForCube,
  convertJSONCordsToSVG,
  convertToSvg
}