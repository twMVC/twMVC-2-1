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
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Blog model)
        {
            //後端驗證
            if (this.ModelState.IsValid)
            {
                model.CreateOn = DateTime.Now;
                MvcApplication.CurrentEntities.Blogs.AddObject(model);
                MvcApplication.CurrentEntities.SaveChanges(); //EF是有交易的
                return RedirectToAction("Article", new { Id = model.Id });
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Article(int id)
        {
            var blog = MvcApplication.CurrentEntities.Blogs.First(x => x.Id == id);
            blog.Hit++;
            MvcApplication.CurrentEntities.SaveChanges();

            return View(blog);
        }

        [HttpPost]
        public ActionResult AddComment(BlogComment model)
        {
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