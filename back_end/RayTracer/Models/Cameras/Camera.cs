using System;
using RayTracer.Models.Elements;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Cameras
{
    public class Camera
    {
        /* The position of the camera or called the eye, which represents,
         * where the camera is located.
        */
        public Point3D position;
        public Point3D lookAt;

        public Camera()
        {
            position = new Point3D();
            lookAt = new Point3D();
        }

        public Camera(Point3D position, Point3D lookAt)
        {
            this.position = position;
            this.lookAt = lookAt;
        }

        public virtual void Render(Scene scene)
        {
            return;
        }

        public virtual Vector3D FindRayDirection(Point2D point)
        {
            return new Vector3D();
        }
    }
}
