// // define meta objects
// var drag = null;

// var canvas = {};
// var inventory = {};
	
// document.onclick = function() {
		
//     canvas = document.getElementById("canvas");
// 	inventory = document.getElementById("inventory");
// 	// attach events listeners
// 	AttachListeners();
// }

// function AttachListeners() {
// 	var ttt = document.getElementsByClassName('inventory'), i;
// 	for (i = 0; i < ttt.length; i++) {
//         document.getElementsByClassName("inventory")[i].onmousedown=Drag;
// 	}
//     document.getElementById("svg1").onmousemove=Drag;
// 	document.getElementById("svg1").onmouseup=Drag;
// }

// // Drag function that needs to be modified;//
// function Drag(e) {
// 	let t = e.target; 
// 	let id = t.id;
// 	let et = e.type;  
// 	let m = MousePos(e);
  
// 	if (!drag && (et == "mousedown")) {
				
// 		if (t.className.baseVal=="inventory") { //if its inventory class item, this should get cloned into draggable?
//             copy = t.cloneNode(true);
// 			copy.onmousedown = Drag;
//             copy.removeAttribute("id");
//             copy._x = 0;
//             copy._y = 0;
// 			canvas.appendChild(copy);
// 			drag = copy;
// 			dPoint = m;
// 		} 
// 		else if (t.className.baseVal=="draggable")	{ //if its just draggable class - it can be dragged around
// 			drag = t;
// 			dPoint = m;
// 		}
// 	}

//     // drag the spawned/copied draggable element now
// 	if (drag && (et == "mousemove")) {
// 		drag._x += m.x - dPoint.x;
// 		drag._y += m.y - dPoint.y;
// 		dPoint = m;
		
// 	 	if(drag.nodeName == "rect"){
// 			drag.setAttribute("x", dPoint.x);
// 			drag.setAttribute("y", dPoint.y);
// 		}
// 		else if(drag.nodeName == "circle"){
// 			drag.setAttribute("cx", dPoint.x);
// 			drag.setAttribute("cy", dPoint.y);
// 		}
 
		
// 	}
		
//     // stop drag
// 	if (drag && (et == "mouseup")) {
//         drag.className.baseVal="draggable";
//         console.log("x: "+drag._x+" y: "+drag._y);
//         document.getElementById("pos_x").value = dPoint.x;
// 		document.getElementById("pos_y").value = dPoint.y;
// 		//the shape that is being added
// 		//console.log(drag);
// 		console.log(svg);
//         drag = null;
        
// 	}
// }
         
// // adjust mouse position to the matrix of SVG & screen size
// function MousePos(event) {
// 		var p = svg1.createSVGPoint();
// 		p.x = event.clientX;
// 		p.y = event.clientY;
// 		var matrix = svg1.getScreenCTM();
//         p = p.matrixTransform(matrix.inverse());
// 		return {
// 			x: p.x,
// 			y: p.y
// 		}
// }