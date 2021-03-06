﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using RayTracer.Models.Json;
using RayTracer.Models.SceneElements;

namespace RayTracer.Controllers
{
    public class RenderController : ApiController
    {
        public HttpResponseMessage Post(JsonObject requestJSON)
        {
            try
            {
                if (requestJSON == null)
                {
                    string exceptionMessage = "The web service didn't receive a correct input";
                    throw new ArgumentNullException(exceptionMessage);
                }

                if(requestJSON.objects == null || requestJSON.objects.Count == 0)
                {
                    string exceptionMessage = "The input doesn't contain any object";
                    throw new ArgumentNullException(exceptionMessage);
                }   

                if(requestJSON.environment == null)
                {
                    string exceptionMessage = "The environment value is null";
                    throw new ArgumentNullException(exceptionMessage);
                }

                if(string.IsNullOrEmpty(requestJSON.environment.fileName))
                {
                    string exceptionMessage = "No file name is provided";
                    throw new ArgumentNullException(exceptionMessage);                    
                }

                if(requestJSON.environment.lights == null || requestJSON.environment.lights.Count == 0 )
                {
                    string exceptionMessage = "The input doesn't contain any light";
                    throw new ArgumentNullException(exceptionMessage);
                }
                if(requestJSON.environment.camera == null)
                {
                    string exceptionMessage = "No camera is received in the input";
                    throw new ArgumentNullException(exceptionMessage); 
                }

                if(requestJSON.environment.winFrame == null)
                {
                    string exceptionMessage = "No window frame is received in the input";
                    throw new ArgumentNullException(exceptionMessage);                     
                }

                Scene scene = requestJSON.ProcessJSON();
                scene.Render();

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(requestJSON.environment.fileName+".jpg", FileMode.Open);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = requestJSON.environment.fileName + ".jpg";

                return result;

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
    }
}
