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

        [HttpPost]
        public ActionResult AddComment(BlogComment model)
        {
            //使用ModelBinding 處理前端Post
            if (this.ModelState.IsValid)
            {
                model.CreateOn = DateTime.Now;
                MvcApplication.CurrentEntities.BlogComments.AddObject(model);
                MvcApplication.CurrentEntities.SaveChanges(); //EF是有交易的
                return RedirectToAction("Comments", new { id = model.Blog.Id });
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Comments(int id)
        {
            return View(MvcApplication.CurrentEntities.BlogComments.Where(x => x.BlogId == id));
        }

        public ActionResult Hot()
        {
            return View(MvcApplication.CurrentEntities.Blogs.OrderByDescending(x => x.Hit).First());
        }

        public ActionResult Part()
        {
            return View(MvcApplication.CurrentEntities.Blogs.OrderByDescending(x => x.CreateOn).Take(5).ToArray());
        }
    }
}