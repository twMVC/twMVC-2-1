using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc.StartFromScratch.Controllers
{
    public class _HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}