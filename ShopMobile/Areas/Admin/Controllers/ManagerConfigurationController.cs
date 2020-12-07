using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerConfigurationController : Controller
    {
        // GET: Admin/ManagerConfiguration
        CauHinhBUS ch = new CauHinhBUS();
        public ActionResult Index()
        {
            if (Session["USER"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public JsonResult Get_Paging_Confi(int pagesize, int pageindex)
        {
            return Json(ch.Get_Paging_Confi(pagesize, pageindex), JsonRequestBehavior.AllowGet);
        }
    }
}