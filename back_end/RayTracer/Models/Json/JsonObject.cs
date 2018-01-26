using System;
using System.Collections.Generic;

namespace RayTracer.Models.Json
{
    public class JsonObject
    {

        List<GeometryJSON> objects;
        EnvironmentJSON environmentJSON;

        public JsonObject(List<GeometryJSON> objects, EnvironmentJSON environmentJSON)
        {
            this.objects = objects;
            this.environmentJSON = environmentJSON;
        }

        public void SetJsonObject(List<GeometryJSON> objects)
        {
            this.objects = objects;
        }

        public List<GeometryJSON> GetJsonObject()
        {
            return objects;
        }

        public void SetEnvironmentJSON(EnvironmentJSON environmentJSON)
        {
            this.environmentJSON = environmentJSON;
        }

        public EnvironmentJSON GetEnvironmentJSON()
        {
            return environmentJSON;
        }
    }
}
