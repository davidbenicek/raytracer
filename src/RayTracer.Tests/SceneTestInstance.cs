using System;
using System.Collections.Generic;
using RayTracer.Models.Geometric;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Tests
{
    public class SceneTestInstance: Scene
    {
        int value;

        public SceneTestInstance(WindowFrame winFrame)
            : base(winFrame)
        {
            this.value = 0;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }

        public override HitInfo GetHitInfo(Models.Elements.Ray ray, List<GeometryObject> ignoreObjects = null)
        {
            switch(value)
            {
                case 0:
                    return null;
                case 1: 
                    HitInfo hitInfo = new HitInfo();
                    hitInfo.hasHit = false;
                    return hitInfo;
                default:
                    return base.GetHitInfo(ray, ignoreObjects);
            }
        }
    }
}
