'use strict';

const $ = require('jquery');
const cp = require('../js/color_picker.js');


// standard global variables
let container, scene, camera, renderer, controls;

// custom global variables
let targetList = [];
let projector, mouse = { x: 0, y: 0 };
// FUNCTIONS 		

 function init(b_color, camera_position) {

	// SCENE
	scene = new THREE.Scene();
	// CAMERA
	let SCREEN_WIDTH = window.innerWidth, SCREEN_HEIGHT = window.innerHeight;
	let VIEW_ANGLE = 45, ASPECT = SCREEN_WIDTH / SCREEN_HEIGHT, NEAR = 0.1, FAR = 20000;
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

	// walls
	let hex = cp.rgbToHex(b_color.r, b_color.g, b_color.b);
	let wallsGeometry = new THREE.CubeGeometry(1000, 1000, 1000);
	let wallBoxMaterial = new THREE.MeshBasicMaterial({ color: hex, side: THREE.BackSide });
	let wallBox = new THREE.Mesh(wallsGeometry, wallBoxMaterial);
	wallBox.position.x = 0;
	wallBox.position.y = 0;
	wallBox.position.z = 0;
	scene.add(wallBox);

	let wireframe = new THREE.WireframeHelper(wallBox, 0x191919);
	scene.add(wireframe);

	// initialize object to perform world/screen calculations
	projector = new THREE.Projector();

	// when the mouse moves, call the given function
	document.addEventListener('mousedown', onDocumentMouseDown, false);

}

function onDocumentMouseDown(event) {
	// the following line would stop any other event handler from firing
	// (such as the mouse's TrackballControls)
	// event.preventDefault();


	// update the mouse variable
	mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
	mouse.y = - (event.clientY / window.innerHeight) * 2 + 1;

	// find intersections

	// create a Ray with origin at the mouse position
	//   and direction into the scene (camera direction)
	let vector = new THREE.Vector3(mouse.x, mouse.y, 1);
	projector.unprojectVector(vector, camera);
	let ray = new THREE.Raycaster(camera.position, vector.sub(camera.position).normalize());

	// create an array containing all objects in the scene with which the ray intersects
	let intersects = ray.intersectObjects(targetList);

}

function addLights (array) {

	for (let i = 0; i < array.length; i++) {
		let lighthex = cp.rgbToHex(array[i].rgbColor.r, array[i].rgbColor.g, array[i].rgbColor.b);
		let light = new THREE.PointLight(lighthex,array[i].intensity.intensity);
		light.position.set(array[i].position.x, array[i].position.y, array[i].position.z);
		scene.add(light);
	}
}

function create_cube(id, color, size, material, point) {
	let idGeometry = new THREE.CubeGeometry(size.x, size.y, size.z);
	let hex = cp.rgbToHex(color.r, color.g, color.b);
	let idMaterial = new THREE.MeshPhongMaterial({ color: hex, side: THREE.BackSide });
	id = new THREE.Mesh(idGeometry, idMaterial);
	id.position.set(point.x, point.y, point.z);
	scene.add(id);
	targetList.push(id);
}

function create_sphere(id, color, size, material, point) {
	let hex = cp.rgbToHex(color.r, color.g, color.b);
	let faceColorMaterial = new THREE.MeshPhongMaterial({ color: hex, vertexColors: THREE.FaceColors });
	let sphereGeometry = new THREE.SphereGeometry(size.x, size.y, size.z);
	id = new THREE.Mesh(sphereGeometry, faceColorMaterial);
	id.position.set(point.x, point.y, point.z);
	scene.add(id);
	targetList.push(id);
}

function jsonToShape(json) {
	for (let i = 0; i < json.length; i++) {

		const obj_color = json[i].color;
		const obj_material = json[i].material;
		const obj_point = json[i].point;
		const obj_size = json[i].size;
		const obj_id = json[i].id;

		if (json[i].shape == "sphere") {
			create_sphere(obj_id, obj_color, obj_size, obj_material, obj_point);
		}
		else if (json[i].shape == "cube") {
			create_cube(obj_id, obj_color, obj_size, obj_material, obj_point);
		}
	}
}

function animate() {
	requestAnimationFrame(animate);
	render();
	update();
}

function update() {
	controls.update();
}

function render() {
	renderer.render(scene, camera);
}

module.exports = {
	init,
	animate,
	jsonToShape,
	render,
	addLights
};