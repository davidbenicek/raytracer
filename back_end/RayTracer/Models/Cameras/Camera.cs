using System;
using RayTracer.Models.Elements;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Cameras
{
    public abstract class Camera
    {
        /* both of the eye and lookAt (Center of Interest) will be used to define,
         * the direction for the camera, which is lookAt - eye, in other words,
         * it is the same of w but without normalization.
        */
        public Point3D eye;
        public Point3D lookAt;
        public double distanceViewPlane = Config.DEFAULT_DISTANCE_VIEW;

        /* This vector will be (0,1,0), which is the Up vector as shown in the report
         * this will allow us to orient the camera and the view plane about the z-axis.
        */
        Vector3D up = Config.DEFAULT_UP_VECTOR;

        /* This vector is the normalized value of the vector gained from the result
         * of eye - lookAt
        */
        Vector3D w;
        //This vector is the normalized vector of the cross product between up and w
        Vector3D u;
        // v is the cross product between w and u.
        Vector3D v;

        public Camera()
        {
            eye = new Point3D();
            lookAt = new Point3D();
            CalculateUVW();
        }

        public Camera(Point3D eye, Point3D lookAt)
        {
            this.eye = eye;
            this.lookAt = lookAt;
            CalculateUVW();
        }

        public Camera(Point3D eye, Point3D lookAt, double distanceViewPlane)
        {
            this.eye = eye;
            this.lookAt = lookAt;
            this.distanceViewPlane = distanceViewPlane;
            CalculateUVW();
        }

        /* This function will do the calculations of:
         * w: by subtracting lookAt from eye, then normalize the value
         * u: by finding the cross product between the up vector which has a default value
         * of (0,1,0), and then normalize the value of u.
         * v: by finding the cross product of w and u.
        */ 
        void CalculateUVW()
        {
            w = eye - lookAt;
            w.Normalize();
            u = up.CrossProduct(w);
            u.Normalize();
            v = w.CrossProduct(u);
        }


        public abstract void Render(Scene scene);
        public abstract Vector3D FindRayDirection(Point3D point);
    }
}
