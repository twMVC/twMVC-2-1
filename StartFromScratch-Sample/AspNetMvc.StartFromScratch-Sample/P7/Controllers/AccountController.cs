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
            //只有在獨立使用者會套Layout
            return View(null, "~/Views/Shared/_LayoutBase.cshtml");
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //確認帳號密碼是否正確
                var user = MvcApplication.CurrentEntities.Users.FirstOrDefault(x => x.Name == model.UserName && x.Password == model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
                else
                {
                    //寫入Cookie
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
            //登出
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}