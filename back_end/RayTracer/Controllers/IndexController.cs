using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RayTracer.Controllers
{
    public class IndexController : Controller
    {
        public String Index()
        {
            var path = "../../front_end/views/home.html";
            var f = System.IO.File.ReadAllText(path);
            return f;
        }

        public String Bundlejs()
        {
            var path = "../../front_end/dist/bundle.js";
            var f = System.IO.File.ReadAllText(path);
            return f;
        }
        public String css()
        {
            var path = "../../front_end/css/stylesheet.css";
            var f = System.IO.File.ReadAllText(path);
            return f;
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

    }
}