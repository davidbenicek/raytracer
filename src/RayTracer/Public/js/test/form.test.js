const chai = require('chai');
const expect = chai.expect;

var render = require('../render.js');

const sample_2d = [{
  "type": "sphere",
  "size": { "x": 50, "y": 50, "z": 50 },
  "point": { "x": 50, "y": 50, "z": 50 },
  "color": { "r": 0, "g": 100, "b": 0 },
  "material": "metal",
  "view": "2D"
}]

const sample_3d = [{
    "type": "sphere",
    "size": { "x": 50, "y": 50, "z": 50 },
    "point": { "x": 50, "y": 50, "z": 50 },
    "color": { "r": 0, "g": 100, "b": 0 },
    "material": "metal",
    "view": "3D"
  }]


//todo 
describe('2D Render front end functions', function () {

  describe('convertToSvg', function () {
    //TODO: Implement and fix this test
    // it('processes  input in 2d', function () {

    //   const svg = render.convertToSvg(sphere, env, "y");
    //   expect(svg).to.equal('<svg width="500"height="500"style="fill:rgb(255,0,0);"><circle cx="50" cy="50" r="50" style="fill:rgb(0,100,0);" /></svg>');

    // });

    
  });
});
