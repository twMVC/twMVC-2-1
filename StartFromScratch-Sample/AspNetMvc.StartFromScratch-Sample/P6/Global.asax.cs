using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AspNetMvc.StartFromScratch.Models;

namespace AspNetMvc.StartFromScratch
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static MvcDemoEntities CurrentEntities
        {
            get
            {
                //當真的有使用時建立MvcDemoEntities
                var entities = (MvcDemoEntities)HttpContext.Current.Items["MvcDemoEntities"];
                if (entities == null)
                {
                    entities = new MvcDemoEntities();
                    //HttpContext.Current.Items 是每一個連線都有的自己的存取空間
                    HttpContext.Current.Items["MvcDemoEntities"] = entities;
                }

                return entities;
            }
        }

        protected void Application_EndRequest()
        {
            //當連線結束時，釋放資料
            var entities = CurrentEntities;
            if (entities != null)
            {
                entities.Dispose();
            }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}