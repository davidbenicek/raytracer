const chai = require('chai');
const expect = chai.expect;

var render = require('../render.js');

const sphere = [{
  "shape": "Sphere",
  "size": { "x": 50, "y": 50, "z": 50 },
  "point": { "x": 50, "y": 50, "z": 50 },
  "color": { "r": 0, "g": 100, "b": 0 },
  "material": "metal"
}]

const cube = [{
  "shape": "Cube",
  "size": { "x": 50, "y": 50, "z": 50 },
  "point": { "x": 50, "y": 50, "z": 50 },
  "color": { "r": 0, "g": 100, "b": 0 },
  "material": "metal"
}]

const shpereAndCube = [{
  "shape": "Sphere",
  "size": { "x": 50, "y": 50, "z": 50 },
  "point": { "x": 50, "y": 50, "z": 50 },
  "color": { "r": 0, "g": 100, "b": 0 },
  "material": "metal"
}, {
  "shape": "Cube",
  "size": { "x": 50, "y": 50, "z": 50 },
  "point": { "x": 50, "y": 50, "z": 50 },
  "color": { "r": 0, "g": 100, "b": 0 },
  "material": "metal"
}]

const env = {
  "fileName": "render.png",
  "winFrame":{"Width": 500, "Height": 500 },
  "background": { "r": 255, "g": 0, "b": 0 }
};


describe('2D Render front end functions', function () {

  describe('convertToSvg', function () {

    it('processes sphere as input in y', function () {

      const svg = render.convertToSvg(sphere, env, "y");
      expect(svg).to.equal('<svg id="svg"onmouseenter="module.showObjectDrag()" width="500"height="500"style="fill:rgb(255,0,0);"><circle class="svg-object" cx="300" cy="300" r="50" style="fill:rgb(0,100,0);"/></svg>');

    });

    it('processes cube as input in z', function () {

      const svg = render.convertToSvg(cube, env, "z");
      expect(svg).to.equal('<svg id="svg"onmouseenter="module.showObjectDrag()" width="500"height="500"style="fill:rgb(255,0,0);"><rect class="svg-object" x="300" y="300" width="50" height="50" style="fill:rgb(0,100,0);"/></svg>');

    });

    it('processes cube and sphere as input in y', function () {

      const svg = render.convertToSvg(shpereAndCube, env, "y");
      expect(svg).to.equal('<svg id="svg"onmouseenter="module.showObjectDrag()" width="500"height="500"style="fill:rgb(255,0,0);"><circle class="svg-object" cx="300" cy="300" r="50" style="fill:rgb(0,100,0);"/><rect class="svg-object" x="300" y="300" width="50" height="50" style="fill:rgb(0,100,0);"/></svg>');

    });

    it('handles no object', function () {

      const svg = render.convertToSvg(undefined, env, "y");
      expect(svg).to.equal('<svg id="svg"onmouseenter="module.showObjectDrag()" width="500"height="500"style="fill:rgb(255,0,0);"></svg>');

    });

    it('handles no environment', function () {

      const svg = render.convertToSvg(shpereAndCube, undefined, "y");
      expect(svg).to.equal('No environment specified for rendering');

    });
    
    it('handles no dimension', function () {

      const svg = render.convertToSvg(shpereAndCube, env);
      expect(svg).to.equal('No dimension to render in');

    });

    it('handles invalid shape as input', function () {

      var obj = [{
        "shape": "invalid",
        "size": { "x": 250, "y": 500, "z": 50 },
        "point": { "x": 400, "y": 400, "z": 400 },
        "color": { "r": 100, "g": 0, "b": 0 },
        "material": "metal"
      }]

      const svg = render.convertToSvg(obj, env, "z");
      expect(svg).to.equal('<svg id="svg"onmouseenter="module.showObjectDrag()" width="500"height="500"style="fill:rgb(255,0,0);"><text x=20 y=20>Object type not supported</text></svg>');
    });

    it('handles shape with invalid body format as input', function () {

      var obj = [{
        "shape": "Sphere",
        "size": { "x": 250, "y": 500, "z": 50 },
        //Missing point here
        "color": { "r": 100, "g": 0, "b": 0 },
        "material": "metal"
      }]

      const svg = render.convertToSvg(obj, env, "z");
      expect(svg).to.equal('You have not specified the object in the correct format');
    });
  })

  describe('getSVGForSphere', function () {

    it('handles no object', function () {
      const svg = render.getSVGForSphere(undefined, "y");
      expect(svg).to.equal('<text x=20 y=20>No object to render</text>');
    });

    it('handles no dimension', function () {

      const svg = render.getSVGForSphere(sphere, "");
      expect(svg).to.equal('<text x=20 y=20>No dimension to render in<text>');

    });
  })

  describe('getSVGForCube', function () {

    it('handles no object', function () {

      const svg = render.getSVGForCube(undefined, "y");
      expect(svg).to.equal('<text x=20 y=20>No object to render</text>');
    });

    it('handles no dimension', function () {

      const svg = render.getSVGForCube(cube, "");
      expect(svg).to.equal('<text x=20 y=20>No dimension to render in</text>');

    });
  });
  describe('Convert from JSON to SVG coordinates', function () {
    it('Calculates conversion from SVG to JSON coordinates in x', function () {
      const res = render.convertJSONCordsToSVG(50,"x");
      expect(res).to.equal(300);
    })
    
    it('Calculates conversion from SVG to JSON coordinates in y', function () {
      const res = render.convertJSONCordsToSVG(100,"y");
      expect(res).to.equal(350);
    })

    it('Calculates conversion from SVG to JSON coordinates in z', function () {
      const res = render.convertJSONCordsToSVG(0,"z");
      expect(res).to.equal(250);
    })
  });
});
