# Raytracer [![Build Status](https://travis-ci.org/davidbenicek/raytracer.svg?branch=master)](https://travis-ci.org/davidbenicek/raytracer)

Welcome to the RayTracer project, create for the KCL Group Project 2017/18.

Team members:

1756850 Alkhamra, Othman Bader <br />
1739256 Benicek, David <br />
1770922 Bari, Aadam Ali <br />
1425704 Mankani Vinod, Hitesh <br />
1755013 Obimma, Timothy Uzochukwu <br />
1783087 Vaddiraju, Nagarjuna <br />

# Contribution guidelines for team members

Since this is a university project we cannot accept any external pull requests, therefore this section is only useful for the team members listed above.

Please **always** work on a branch and label your branches in the following convention
`(issue number)/(name of branch)`

Once your branch is ready to be merged (that is, it has been run localy, tested and Travis is passing), please raise a pull request and get someone from the other work unit to review it. 


# Instalation and running the code

To run the code, follow the these steps:

## The front end

All front end code is kept in src/RayTracer/Public

### Bundle and run 
To bundle the code and transpile the individual JS files from ES6 to browser runnable JS (using browserify) follow these steps:

* Make sure you have `npm` installed on your machine (typing `which npm` in terminal should resolve to a path if you have it installed)
* Run `npm install` from the Public directory (i.e. src/RayTracer/Public/)
* Run `npm run bundle` to run browserify. If you are developing you'll likely want to bundle frequently. For this we have a small bash script that will bundle your code every couple seconds. Run `./hotreload.sh` to start it. 

Please note, if you wish to run the front end without the backend, you can simple open the html files in views in your browser and it should work (you may need to change the extension from `.cshtml` to `.html`).


#### Running Tests

* To run tests simply make sure you have previously ran the code as described above
* Run the `npm test` command in the Public folder

If you wish to see a comprehensive coverage report for the front end files, run `npm run coverage`. This will create a new folder in the directory called `coverage`, `/coverage/index.html` will show you a graphical view of all tested files. Please avoid committing the output of this to the repo.

## The back end:

* Install Visual Studio

* Press play (aka run)! Your default browser should open up to `localhost:1200` and display the landing page.