using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopMobile
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application["online"] = 1012;
        }
        protected void Session_Start()
        {
            Application["online"] = int.Parse(Application["online"].ToString())+1;
            Session["giohang"] = null;
        }
    }
}
