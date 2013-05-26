using System;
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

        public ActionResult Part()
        {
            using (var entites = new MvcDemoEntities())
            {
                //使用Entity Framework與Linq取資料
                return View(entites.Blogs.OrderByDescending(x => x.CreateOn).Take(5).ToArray());
            }
        }
    }
}