const chai = require('chai');
const expect = chai.expect;

var drag_drop = require('../drag_drop.js');
var form = require('../form.js');


describe('Drag and drop', function () {

    it('Starts object drag', function () {
      drag_drop.startObjectDrag("test")
      expect(drag_drop.new_object).to.equal("test");
      expect(drag_drop.dragged_id).to.equal("object0");
      drag_drop.startObjectDrag("test2")
      expect(drag_drop.new_object).to.equal("test2");
      expect(drag_drop.dragged_id).to.equal("object1");
    });

    it('Clears dragged object', function () {
      drag_drop.clearObjectDrag()
      expect(drag_drop.new_object).to.equal("");
      expect(drag_drop.dragged_id).to.equal("");
    });

    it('Finds id in JSON array', function () {
      form.objectsJSON = [{ id: "not this one"},{ id: "not this one"},{ id: "not this one"},{ id: "test"},{ id: "not this one"}]
      const res = drag_drop.findObjectInJSON("test")
      expect(res).to.equal('3');
    });

    it('Handles search in undefined', function () {
      form.objectsJSON = undefined
      const res = drag_drop.findObjectInJSON("test")
      expect(res).to.equal(-1);
    });

    it('Handles search in empty', function () {
      form.objectsJSON = []
      const res = drag_drop.findObjectInJSON("test")
      expect(res).to.equal(-1);
    });

    it('Adds rect to JSON', function () {
      drag_drop.addToJSON("rect","id",100,100)
      expect(form.objectsJSON[0].id).to.equal("id");
    });

    it('Handles adding duplicate id', function () {
      drag_drop.addToJSON("rect","id",)
      expect(form.objectsJSON.length).to.equal(1);
    });

    it('Adds sphere to JSON', function () {
      drag_drop.addToJSON("sphere","id2",100,100)
      expect(form.objectsJSON[1].id).to.equal("id2");
    });

    it('Modifies position of existing shape', function () {
      drag_drop.updateJSONWithMove("id","y",50,50)
      expect(form.objectsJSON[0].point.x).to.equal(50);
      expect(form.objectsJSON[0].point.y).to.equal(50);
      expect(form.objectsJSON[0].point.z).to.equal(100);
    });

    it('Handles position modification of non existant shape', function () {
      drag_drop.updateJSONWithMove("non-id","y",150,150)
      expect(form.objectsJSON[0].point.x).to.equal(50);
    });  

    it('Calculates conversion from SVG to JSON coordinates in x', function () {
      const res = drag_drop.convertSVGCordsToJSON(500,"x");
      expect(res).to.equal(250);
    })
    
    it('Calculates conversion from SVG to JSON coordinates in y', function () {
      const res = drag_drop.convertSVGCordsToJSON(300,"y");
      expect(res).to.equal(50);
    })

    it('Calculates conversion from SVG to JSON coordinates in z', function () {
      const res = drag_drop.convertSVGCordsToJSON(1000,"z");
      expect(res).to.equal(750);
    })
  
});
