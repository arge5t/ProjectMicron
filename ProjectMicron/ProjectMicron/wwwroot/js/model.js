
import { OrbitControls } from 'https://cdn.jsdelivr.net/npm/three@0.121.1/examples/jsm/controls/OrbitControls.js'
import { GLTFLoader } from '../three.js-master/examples/jsm/loaders/GLTFLoader.js'

let scene;
let camera;
let renderer;

function init() {



	//Scene
	scene = new THREE.Scene()
	scene.background = new THREE.Color(0x003153);

	//Camera
	camera = new THREE.PerspectiveCamera(70, window.innerWidth / window.innerHeight, 0.1, 3000);
	camera.position.z = 100;
	camera.position.y = 700;
	camera.position.x = 1020;




	//render
	renderer = new THREE.WebGLRenderer({ antialias: true })
	renderer.setSize(500, 500)
	document.querySelector('.d__model').appendChild(renderer.domElement);

	//OrbitControls
	const controls = new OrbitControls(camera, renderer.domElement);
	controls.update();
	controls.enableDamping = true;
	controls.minDistance = 10;

	//light
	const ambient = new THREE.AmbientLight(0xffffff, 1);
	scene.add(ambient)

	let light = new THREE.PointLight(0xc4c4c4, 1);
	light.position.set(0, 400, 500);
	scene.add(light)

	let light2 = new THREE.PointLight(0xc4c4c4, 1);
	light2.position.set(500, 300, 500);
	scene.add(light2)

	let light3 = new THREE.PointLight(0xc4c4c4, 1);
	light3.position.set(0, 300, -500);
	scene.add(light3)

	let light4 = new THREE.PointLight(0xc4c4c4, 1);
	light4.position.set(-500, 300, 500);
	scene.add(light4)

	//model
	const loader = new GLTFLoader();
	loader.load('./model/scene.gltf', gltf => {
		scene.add(gltf.scene);
	},
		function (error) {
			console.log('Error: ' + error)
		}
	)

	//Resize
	window.addEventListener('resize', onWindowResize, false)

	function onWindowResize() {
		//	camera.aspect = window.innerWidth / window.innerHeight;
		//camera.updateProjectionMatrix();

		//renderer.setSize(window.innerWidth, window.innerHeight)
	}

	function animate() {
		requestAnimationFrame(animate)
		scene.rotation.y += 0.015;
		controls.update();
		renderer.render(scene, camera)
	}
	animate()
}
init()