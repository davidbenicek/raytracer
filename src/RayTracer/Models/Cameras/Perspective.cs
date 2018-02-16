using System;
using rayTracer.Models.Elements;
using RayTracer.Models.Elements;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Models.Cameras
{
    public class Perspective : Camera
    {
        /* both of the position(eye) and lookAt (Center of Interest) will be used to define,
         * the direction for the camera, which is lookAt - eye, in other words,
         * it is the same of w but without normalization.
        */

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

        public Perspective()
            : base()
        {
            CalculateUVW();
        }

        public Perspective(Point3D position, Point3D lookAt)
            : base(position,lookAt)
        {
            CalculateUVW();
        }

        public Perspective(Point3D position, Point3D lookAt, double distanceViewPlane)
        {
            this.position = position;
            this.lookAt = lookAt;
            this.distanceViewPlane = distanceViewPlane;
            CalculateUVW();
        }

        public Perspective(Perspective camera)
        {
            this.position = camera.position;
            this.lookAt = camera.lookAt;
            this.distanceViewPlane = camera.distanceViewPlane;
            CalculateUVW();
        }

        /* In this method, adding the value distanceViewPlane * w or subtracting it,
         * depends on how you calculate w, and so if it is 
         * lookAt - position then you add it to the equation
         * else you need to subtract it
        */
        public override Vector3D FindRayDirection(Point2D point)
        {
            Vector3D rayDirection = point.x * u + point.y * v + distanceViewPlane * w;
            rayDirection.Normalize();
            return rayDirection;
        }

        /*This function will go through the window frame, pixel by pixel,
         * and then by taking the middle of each pixel for x and y,
         * we find the direction of those values with respect to the camera,
         * then create a new ray, from the origin and the calculated direction
         * and return the color.
        */
        public override void Render(Scene scene)
        {
            Ray ray = new Ray();
            ray.origin = position;

            for (int row = 0; row < scene.GetHeight(); ++row) // We are going up in the window frame
            {
                for (int col = 0; col < scene.GetWidth(); ++col)
                { // We are going on the horizontal part, in other words
                   // across the same row.
                    ColorRGB pixel_color = new ColorRGB();

                    Point2D pixel =
                    new Point2D(col - 0.5 * scene.GetWidth(),
                                row - 0.5 * scene.GetHeight());

                    ray.direction = FindRayDirection(pixel);
                    /* Now we need to call the tracer that we have to find the color
                     * to find the color of that pixel.
                    */ 
                    pixel_color = scene.GetTracer().TraceRay(ray);
                    /* Here the x axis will be equal to column; since it is related to the width in the final image
                     * And the y axis will be based on the height, but since we are moving from down to up;
                     * the j will be height - currentHeightValue(row) - 1; and the -1 for programming issues;
                     * since the index of first one will be 0 not 1; that's y wee need -1;
                    */ 
                    scene.DisplayPixel(col, scene.GetHeight()- row - 1, pixel_color);
                }
            }
        }


        /* This function will do the calculations of:
         * w: by subtracting eye's position from eye's lookAt, then normalize the value
         * u: by finding the cross product between the up vector which has a default value
         * of (0,1,0), and then normalize the value of u.
         * v: by finding the cross product of w and u.
        */
        void CalculateUVW()
        {
            w = lookAt - position;
            w.Normalize();
            u = up.CrossProduct(w);
            u.Normalize();
            v = w.CrossProduct(u);
        }

    }
}
