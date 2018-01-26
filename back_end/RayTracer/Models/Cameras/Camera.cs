using System;
using RayTracer.Models.Elements;

namespace RayTracer.Models.Cameras
{
    public class Camera
    {
        protected Point3D eye;
        protected Point3D lookAt;
        protected double distanceViewPlane;

        public Camera()
        {
            eye = new Point3D();
            lookAt = new Point3D();
        }

        public Camera(Point3D eye, Point3D lookAt, double distanceViewPlane)
        {
            this.eye = eye;
            this.lookAt = lookAt;
            this.distanceViewPlane = distanceViewPlane;
        }

    }
}
