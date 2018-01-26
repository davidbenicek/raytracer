#Frontend

In this folder you will find the frontend code.


#Bundle and run 
To bundle the code and transpile it from ES6 to browser runnable JS (using browserify) follow these steps:

* Make sure you have `npm` installed on your machine (which npm should resolve to a path if you have it)
* Run `npm install` from this root directory (i.e. raytracer/front_end/)
* Run `npm run bundle` to run browserify once, `npm run dev` for hot reloading (you may need to have previously ran bundle)


# Running Tests

* To run tests simply make sure you have previously ran the code as discribed above
* Run the `npm test` command

If you wish to see a comprehensive coverage report for the fron end files, run `npm run coverage`. This will create a new folder in the directory called coverage, /coverage/index.html will show you a graphical view of all tested files.

