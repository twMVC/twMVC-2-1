using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using AspNetMvc.StartFromScratch.Models;

namespace AspNetMvc.StartFromScratch.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View(null, "~/Views/Shared/_LayoutBase.cshtml");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = MvcApplication.CurrentEntities.Users.FirstOrDefault(x => x.Name == model.UserName && x.Password == model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (string.IsNullOrWhiteSpace(model.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
            }

            return View(null, "~/Views/Shared/_LayoutBase.cshtml");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}