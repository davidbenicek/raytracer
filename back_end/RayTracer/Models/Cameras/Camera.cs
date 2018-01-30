using System;
using RayTracer.Models.Elements;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Cameras
{
    public abstract class Camera
    {
        /* The position of the camera or called the eye, which represents,
         * where the camera is located.
        */
        public Point3D position;

        public Camera()
        {
            position = new Point3D();
        }

        public Camera(Point3D position)
        {
            this.position = position;
        }

        public abstract void Render(Scene scene);

        public abstract Vector3D FindRayDirection(Point2D point);
    }
}
