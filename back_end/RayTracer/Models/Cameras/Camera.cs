using System;
using RayTracer.Models.Elements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Cameras
{
    public class Camera
    {
        public Point3D eye;
        public Point3D lookAt;
        public double distanceViewPlane = Config.DEFAULT_DISTANCE_VIEW;

        public Camera()
        {
            eye = new Point3D();
            lookAt = new Point3D();
        }

        public Camera(Point3D eye, Point3D lookAt)
        {
            this.eye = eye;
            this.lookAt = lookAt;
        }

        public Camera(Point3D eye, Point3D lookAt, double distanceViewPlane)
        {
            this.eye = eye;
            this.lookAt = lookAt;
            this.distanceViewPlane = distanceViewPlane;
        }

    }
}
