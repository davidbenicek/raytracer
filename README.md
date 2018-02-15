# Raytracer

Welcome to the RayTracer project, create for the KCL Group Project 2017/18.

Team members:

1756850 Alkhamra, Othman Bader <br />
1739256 Benicek, David <br />
1770922 Bari, Aadam Ali <br />
1425704 Mankani Vinod, Hitesh <br />
1755013 Obimma, Timothy Uzochukwu <br />
1783087 Vaddiraju, Nagarjuna <br />

#Instalation and running the code

To run the code, follow the these steps:

## The front end

All front end code is kept in src/RayTracer/Public

### Bundle and run 
To bundle the code and transpile the individual JS files from ES6 to browser runnable JS (using browserify) follow these steps:

* Make sure you have `npm` installed on your machine (typing `which npm` in terminal should resolve to a path if you have it installed)
* Run `npm install` from the Public directory (i.e. src/RayTracer/Public/)
* Run `npm run bundle` to run browserify once, `npm run dev` for hot reloading (you will need to have previously ran `npm run bundle` for this to work...or have the `dist/bundle.js` file already created)


#### Running Tests

* To run tests simply make sure you have previously ran the code as described above
* Run the `npm test` command in the Public folder

If you wish to see a comprehensive coverage report for the front end files, run `npm run coverage`. This will create a new folder in the directory called coverage, `/coverage/index.html` will show you a graphical view of all tested files. Please avoid committing the output of this to the repo.

## The back end:

* Install Visual Studio

* Press play (aka run)! Your default browser should open up to `localhost:8080` and display the landing page.