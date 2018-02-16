﻿using System;
using System.Collections.Generic;
using rayTracer.Models.Elements;
using RayTracer.Models.Cameras;
using RayTracer.Models.Lights;
using RayTracer.Models.Geometric;
using RayTracer.Models.Util;
using RayTracer.Models.Elements;
using RayTracer.Models.Tracing;
using RayTracer.Models.Materials;
using System.Drawing;

namespace RayTracer.Models.SceneElements
{
    public class Scene
    {
        List<Light> lightsList;
        List<GeometryObject> objectsList;
        ColorRGB background;
        WindowFrame winFrame;
        ColorRGB[,] finalPixels;
        Camera camera;
        Light ambientLight;
        Tracer tracer;
        string fileName;

        public Scene(WindowFrame winFrame)
        {
            lightsList = new List<Light>();
            objectsList = new List<GeometryObject>();
            finalPixels = new ColorRGB[winFrame.width, winFrame.height];
            this.winFrame = winFrame;
            background = Config.DEFAULT_COLOR;
            this.camera = new Perspective();
            tracer = new Tracer(this);
        }

        public Scene(WindowFrame winFrame, string fileName, ColorRGB background, Camera camera)
        {
            lightsList = new List<Light>();
            objectsList = new List<GeometryObject>();
            finalPixels = new ColorRGB[winFrame.width, winFrame.height];
            this.winFrame = winFrame;
            tracer = new Tracer(this);
            this.camera = camera;
            this.fileName = fileName;
            this.background = background;
        }

        public Scene(Scene sceneObj)
        {
            SetLights(sceneObj.lightsList);
            SetObjects(sceneObj.objectsList);

            if (sceneObj.background != null)
            {
                background = new ColorRGB(sceneObj.GetBackgroundColor());
            }

            winFrame = sceneObj.winFrame;
            finalPixels = new ColorRGB[winFrame.width, winFrame.height];
            tracer = sceneObj.tracer;
            camera = sceneObj.camera;
        }

        public Scene(List<Light> lights, List<GeometryObject> objectsList, ColorRGB Background, WindowFrame winFrame, Camera camera)
        {
            SetLights(lights);
            SetObjects(objectsList);
            background = new ColorRGB(Background);
            this.winFrame = winFrame;
            finalPixels = new ColorRGB[winFrame.width, winFrame.height];
            this.camera = camera;
            tracer = new Tracer(this);
        }

        public void AddObject(GeometryObject geoObj)
        {
            objectsList.Add(geoObj);
        }

        public void AddLight(Light lightObj)
        {
            lightsList.Add(lightObj);
        }

        public ColorRGB GetBackgroundColor()
        {
            return background;
        }

        public void SetCamera(Perspective camera)
        {
            this.camera = new Perspective(camera);
        }

        public void SetLights(List<Light> lights)
        {
            lightsList = new List<Light>();
            lightsList.AddRange(lights);
        }

        public void SetObjects(List<GeometryObject> objects)
        {
            objectsList = new List<GeometryObject>();
            objectsList.AddRange(objectsList);
        }

        public List<Light> GetLights()
        {
            return lightsList;
        }

        public List<GeometryObject> GetObjects()
        {
            return objectsList;
        }

        public ColorRGB[,] GetFinalPixels()
        {
            return finalPixels;
        }

        public void SetAmbientLight(Light ambientLight)
        {
            this.ambientLight = ambientLight;
        }

        public Light GetAmbientLight()
        {
            return ambientLight;
        }

        public void SetWidth(int width)
        {
            winFrame.width = width;
        }

        public int GetWidth()
        {
            return winFrame.width;
        }

        public void SetHeight(int height)
        {
            winFrame.height = height;
        }

        public int GetHeight()
        {
            return winFrame.height;
        }

        public Tracer GetTracer()
        {
            return tracer;
        }

        public void Render()
        {
            if (camera != null)
            {
                camera.Render(this);
                FinalPicture();
            }
        }

        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }

        /* In this method, we will loop over the whole objects in the scene,
         * to check which object did the ray hit, also, we if there are 
         * many objects which were hit by the ray, return the closest one
         * of theses objects in a an object called HitInfo, also check, if 
         * this object is in the ignore objects, and if it is there, so don't do
         * anything on that object
        */
        public HitInfo GetHitInfo(Ray ray, List<GeometryObject> ignoreObjects = null)
        {
            try
            {
                /* Create an object of hitInfo, and assign a value to it's tMin,
                 * to be the maximum possible of a double, to check that 
                 * with the values returned from the loop over objects
                */

                HitInfo hitInfo = new HitInfo();
                hitInfo.tMin = double.MaxValue;

                foreach (GeometryObject geoObj in objectsList)
                {
                    /* Check if the geoObj is in the ignore list of objects and so
                     * if it is there then just continue and do nothing
                     */
                    if (ignoreObjects != null && ignoreObjects.Contains(geoObj))
                    {
                        continue;
                    }

                    HitInfo intersectInfo = geoObj.Intersect(ray);
                    /* If the ray didn't hit the object, then just continue,
                     * and ignore that object, else check the hit info with the current ones
                     * to check if it is smaller than the current, and so take them,
                     * this will be based on the tMin value
                    */
                    if (!intersectInfo.hasHit)
                    {
                        continue;
                    }

                    if (intersectInfo.tMin < hitInfo.tMin)
                    {
                        hitInfo = new HitInfo(intersectInfo);
                    }
                }

                return hitInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisplayPixel(int x, int y, ColorRGB PixelColor)
        {
            ColorRGB tempColor = new ColorRGB
            {
                r = Math.Min(PixelColor.r, 1.0f),
                g = Math.Min(PixelColor.g, 1.0f),
                b = Math.Min(PixelColor.b, 1.0f)
            };

            finalPixels[x, y] = new ColorRGB(tempColor);
        }

        public void CreateScene()
        {
            camera = new Perspective(new Point3D(0, 0, 500), new Point3D(-5, 0, 0), 850);

            background = new ColorRGB(0.2,0.4,0.4);

            // Build lights
            Light ambient_ptr = new AmbientLight(new ColorRGB(.3, .3, .3), 1);
            SetAmbientLight(ambient_ptr);

            Light point_ptr = new Light(new Point3D(0, 55, 95), new ColorRGB(1, 0, 0), 0.5);
            AddLight(point_ptr);

            Light point_ptr2 = new Light(new Point3D(50, 55, 75), new ColorRGB(0, 1, 0),0.4);
            AddLight(point_ptr2);

            // Build objects
            Sphere metal_sphere = new Sphere(new Point3D(-50, 0, 60), 30, new Flat(new ColorRGB(0.0, 0.0, 1)));
            AddObject(metal_sphere);

            Sphere plastic_sphere = new Sphere(new Point3D(50, 0, 0), 40, new Flat(Config.WHITE));
            AddObject(plastic_sphere);

            Sphere mirror_sphere = new Sphere(new Point3D(-60, 70, 0), 40, new Flat(new ColorRGB(1,0,0)));
            AddObject(mirror_sphere);

            Sphere water_sphere = new Sphere(new Point3D(0, -30, 100), 70, new Flat(new ColorRGB(1,0,1)));
            AddObject(water_sphere);

        }

        public void FinalPicture()
        {
            try
            {

                //SaveImage();
                Bitmap bitmap = new Bitmap(winFrame.width, winFrame.height);

                for (int Xcount = 0; Xcount < winFrame.width; Xcount++)
                {
                    for (int Ycount = 0; Ycount < winFrame.height; Ycount++)
                    {
                        ColorRGB pixel = finalPixels[Xcount, Ycount];

                        int blue = (int)(Utility.Clamp(0, 1, pixel.b) * 255.0f);
                        int green = (int)(Utility.Clamp(0, 1, pixel.g) * 255.0f);
                        int red = (int)(Utility.Clamp(0, 1, pixel.r) * 255.0f);

                        byte[] color = { (byte)blue, (byte)green, (byte)red };

                        bitmap.SetPixel(Xcount, Ycount, Color.FromArgb(red, green, blue));
                    }
                }

                //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

                bitmap.Save("./" + fileName + ".jpg");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetCamera(Camera camera)
        {
            this.camera = camera;
        }
    }
}