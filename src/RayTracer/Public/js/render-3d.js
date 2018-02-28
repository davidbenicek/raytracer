const $ = require('jquery');

$(window).on('load', function () {
	// standard global variables
	var container, scene, camera, renderer, controls, stats;
	var keyboard = new THREEx.KeyboardState();

	// custom global variables
	var targetList = [];
	var projector, mouse = { x: 0, y: 0 };

	// FUNCTIONS 		

	function rgbToHex(r, g, b) {
		return "#" + (1 << 24 | r << 16 | g << 8 | b).toString(16).slice(1)
	}

	exports.init = function (b_color, camera_position, light_position) {

		// SCENE
		scene = new THREE.Scene();
		// CAMERA
		var SCREEN_WIDTH = window.innerWidth, SCREEN_HEIGHT = window.innerHeight;
		var VIEW_ANGLE = 45, ASPECT = SCREEN_WIDTH / SCREEN_HEIGHT, NEAR = 0.1, FAR = 20000;
		camera = new THREE.PerspectiveCamera(VIEW_ANGLE, ASPECT, NEAR, FAR);
		scene.add(camera);
		camera.position.set(camera_position.x, camera_position.y, camera_position.z);
		camera.lookAt(scene.position);
		// RENDERER
		if (Detector.webgl)
			renderer = new THREE.WebGLRenderer({ antialias: true });
		else
			renderer = new THREE.CanvasRenderer();
		renderer.setSize(SCREEN_WIDTH, SCREEN_HEIGHT);
		container = document.getElementById('ThreeJS');
		container.appendChild(renderer.domElement);
		// EVENTS
		THREEx.WindowResize(renderer, camera);
		THREEx.FullScreen.bindKey({ charCode: 'm'.charCodeAt(0) });
		// CONTROLS
		controls = new THREE.OrbitControls(camera, renderer.domElement);
		// LIGHT
		var light = new THREE.PointLight(0xffffff);
		light.position.set(light_position.x, light_position.y, light_position.z);
		scene.add(light);
		// FLOOR
		/* var floorTexture = new THREE.ImageUtils.loadTexture( 'images/checkerboard.jpg' );
		floorTexture.wrapS = floorTexture.wrapT = THREE.RepeatWrapping; 
		floorTexture.repeat.set( 10, 10 ); */

		// walls
		var skyBoxGeometry = new THREE.CubeGeometry(1000, 1000, 1000);
		let hex = rgbToHex(b_color.r, b_color.g, b_color.b);
		var skyBoxMaterial = new THREE.MeshBasicMaterial({ color: hex, side: THREE.BackSide });
		var skyBox = new THREE.Mesh(skyBoxGeometry, skyBoxMaterial);
		skyBox.position.x = 0;
		skyBox.position.y = 0;
		skyBox.position.z = 0;
		scene.add(skyBox);

		wireframe = new THREE.WireframeHelper( skyBox, 0x191919);
		scene.add( wireframe );
 
		var skyBoxGeometry = new THREE.CubeGeometry(10, 10, 10);
		var skyBoxMaterial = new THREE.MeshBasicMaterial({ color: 0xff0000, side: THREE.BackSide });
		var skyBox1 = new THREE.Mesh(skyBoxGeometry, skyBoxMaterial);
		skyBox1.position.x = 5;
		skyBox1.position.y = 5;
		skyBox1.position.z = 5;
		scene.add(skyBox1);

		////////////
		// CUSTOM //
		////////////


		// initialize object to perform world/screen calculations
		projector = new THREE.Projector();

		// when the mouse moves, call the given function
		document.addEventListener('mousedown', onDocumentMouseDown, false);

	}

	function onDocumentMouseDown(event) {
		// the following line would stop any other event handler from firing
		// (such as the mouse's TrackballControls)
		// event.preventDefault();

		console.log("Click.");

		// update the mouse variable
		mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
		mouse.y = - (event.clientY / window.innerHeight) * 2 + 1;

		// find intersections

		// create a Ray with origin at the mouse position
		//   and direction into the scene (camera direction)
		var vector = new THREE.Vector3(mouse.x, mouse.y, 1);
		projector.unprojectVector(vector, camera);
		var ray = new THREE.Raycaster(camera.position, vector.sub(camera.position).normalize());

		// create an array containing all objects in the scene with which the ray intersects
		var intersects = ray.intersectObjects(targetList);

		// if there is one (or more) intersections
		if (intersects.length > 0) {
			console.log("Hit @ " + toString(intersects[0].point));
			// change the color of the closest face.
			intersects[0].face.color.setRGB(0.8 * Math.random() + 0.2, 0, 0);
			intersects[0].object.geometry.colorsNeedUpdate = true;
		}

	}

	function toString(v) { return "[ " + v.x + ", " + v.y + ", " + v.z + " ]"; }


	function create_cube(id, color, size, material, point) {
		var idGeometry = new THREE.CubeGeometry(size.x, size.y, size.z);
		let hex = rgbToHex(color.r, color.g, color.b);
		var idMaterial = new THREE.MeshBasicMaterial({ color: hex, side: THREE.BackSide });
		var id = new THREE.Mesh(idGeometry, idMaterial);
		id.position.set(point.x, point.y, point.z);
		scene.add(id);
		targetList.push(id);
	}

	function create_sphere(id, color, size, material, point) {
		let hex = rgbToHex(color.r, color.g, color.b);
		var faceColorMaterial = new THREE.MeshBasicMaterial({ color: hex, vertexColors: THREE.FaceColors });
		var sphereGeometry = new THREE.SphereGeometry(size.x, size.y, size.z);
		var id = new THREE.Mesh(sphereGeometry, faceColorMaterial);
		id.position.set(point.x, point.y, point.z);
		scene.add(id);
		targetList.push(id);
	}

	exports.jsonToShape = function (json) {
		for (i = 0; i < json.length; i++) {

			obj_color = json[i].color;
			obj_material = json[i].material;
			obj_point = json[i].point;
			obj_size = json[i].size;
			obj_id = json[i].id;

			if (json[i].shape == "Sphere") {
				create_sphere(obj_id, obj_color, obj_size, obj_material, obj_point);
			}
			else if (json[i].shape == "Cube") {
				create_cube(obj_id, obj_color, obj_size, obj_material, obj_point);
			}
		}
	}

	exports.animate = function () {
		requestAnimationFrame(exports.animate);
		exports.render();
		update();
	}


	function update() {
		if (keyboard.pressed("z")) {
			// do something
		}

		controls.update();
	}

	exports.render = function render() {
		renderer.render(scene, camera);
	}
});
