using System;
using System.Collections.Generic;
using System.Linq;
using RayTracer.Models.Cameras;
using RayTracer.Models.Geometric;
using RayTracer.Models.Lights;
using RayTracer.Models.Materials;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Json
{
    public class JsonObject
    {

        public List<GeometryJSON> objects;
        public EnvironmentJSON environment;

        public JsonObject()
        {
            
        }

        public JsonObject(List<GeometryJSON> objects, EnvironmentJSON environment)
        {
            this.objects = objects;
            this.environment = environment;
        }

        public Scene ProcessJSON()
        {
            Scene scene = ProcessEnvironment();
            scene = SetObjects(scene);
            scene = SetLights(scene);
            return scene;
        }
        /*This method will set the lights of the scene, based on the light list 
         * received by the JSON.
        */ 
        public Scene SetLights(Scene scene)
        {
            try
            {
                if(environment == null)
                {
                    string exceptionMessage = "No environment in the JSON object";
                    throw new ArgumentNullException(exceptionMessage);
                }

                if(environment.lights == null && environment.lights.Count == 0)
                {
                    string exceptionMessage = "No lights in the JSON object";
                    throw new ArgumentNullException(exceptionMessage);
                }

                /* The first light received will be considered as the ambient,
                 * which means that it will be the main light in the scene,
                 * that's why, the lights list is sent without the first element
                 * and that's done by using the skip function which is one of the 
                 * LINQ functions.
                */

                scene.SetAmbientLight(GetAmbientLight(environment.lights.FirstOrDefault()));

                List<Light> lightsList = environment.lights.Skip(1).ToList();

                if(lightsList == null || lightsList.Count == 0)
                {
                    lightsList = new List<Light>();
                }

                scene.SetLights(lightsList);

                return scene;
            }
            catch(ArgumentException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /*This method will create the objects from the list received by the JSON
        */ 
        public Scene SetObjects(Scene scene)
        {
            try
            {
                if (objects == null || objects.Count == 0)
                {
                    string exceptionMessage = "No objects were in the JSON object";
                    throw new ArgumentNullException(exceptionMessage);
                }

                //Process the environment variable, and get the scene object
                foreach (GeometryJSON geoObj in objects)
                {
                    scene.AddObject(GetObject(geoObj));
                }

                return scene;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* This method process the environment parameters received in the JSON,
         * such as the window frame details, and camera, then create an object
         * of the scene which will be used to add objects and lights to the scene.
         */
        private Scene ProcessEnvironment()
        {
            try
            {
                if(environment == null)
                {
                    string exceptionMessage = "No environment in the JSON object";
                    throw new ArgumentNullException(exceptionMessage);
                }
                if(environment.winFrame == null)
                {
                    string exceptionMessage = "No Window frame in the JSON object";
                    throw new ArgumentNullException(exceptionMessage);
                }
                if (environment.camera == null)
                {
                    string exceptionMessage = "No camera in the JSON object";
                    throw new ArgumentNullException(exceptionMessage);
                }

                if (string.IsNullOrEmpty(environment.fileName))
                {
                    string exceptionMessage = "No file name in the JSON object";
                    throw new ArgumentNullException(exceptionMessage);
                }

                Scene scene = new Scene(environment.winFrame, environment.fileName, environment.background, environment.camera);
                return scene;

            }
            catch(ArgumentNullException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /*This function will return the object based on the shape received by the JSON,
         * if no shape is received means that there is a problem, and so throw an exception
         * else return the shape which has that name
        */
        private GeometryObject GetObject(GeometryJSON geoObj)
        {
            try
            {
                string shape = geoObj.shape.ToLower();

                if (string.IsNullOrEmpty(shape))
                {
                    string exceptionMessage = "No object shape is received by the JSON";
                    throw new ArgumentNullException(exceptionMessage);
                }

                if (shape.Equals("sphere"))
                {
                    Sphere sphere = new Sphere(geoObj.point, geoObj.size.x, GetMaterial(geoObj));
                    return sphere;
                }

                //else if (shape.Equals("cube"))
                //{
                //    //Return cube
                //}

                string exceMessage = "Shape is not defined";
                throw new ArgumentException(exceMessage);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* This function will get the material of the object based on the text sent by the JSON,
         * if there is no text sent by the JSON then just use the default material.
         * Material text will be the key of the dictionary which is saving the materials
         * and so based on that key, the material is returned, and the color of the material
         * will be the color received in the JSON, and if it is not received it will be the black on
        */
        private Material GetMaterial(GeometryJSON geoObj)
        {
            try
            {
                string material = geoObj.material.ToLower();

                if (string.IsNullOrEmpty(material))
                {
                    string exceptionMessage = "No material is received by the JSON";
                    throw new ArgumentNullException(exceptionMessage);
                }

                Material materialObject;

                //If no metal is received then use the default one.
                if (!Config.MATERIALS_DICTIONARY.TryGetValue(material, out materialObject))
                {
                    return Config.DEFAULT_MATERIAL_OBJECT;
                }
                //Set the color of the object, to the color received by the JSON, if not received it will be the default color
                materialObject.rgbColor = geoObj.color;

                return materialObject;

            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AmbientLight GetAmbientLight(Light light)
        {
            AmbientLight ambientLight = new AmbientLight(light.rgbColor, light.intensity);
            return ambientLight;
        }

     }

}
