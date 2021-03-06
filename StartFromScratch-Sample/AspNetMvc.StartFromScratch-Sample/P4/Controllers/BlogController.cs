﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMvc.StartFromScratch.Models;

namespace AspNetMvc.StartFromScratch.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hot()
        {
            using (var entites = new MvcDemoEntities())
            {
                return View(entites.Blogs.OrderByDescending(x => x.Hit).First());
            }
        }

        //public ActionResult Hot()
        //{
        //    return View(MvcApplication.CurrentEntities.Blogs.OrderByDescending(x => x.Hit).First());
        //}

        public ActionResult Part()
        {
            using (var entites = new MvcDemoEntities())
            {
                return View(entites.Blogs.OrderByDescending(x => x.CreateOn).Take(5).ToArray());
            }
        }
    }
}