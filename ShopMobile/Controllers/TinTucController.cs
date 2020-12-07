using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;

namespace ShopMobile.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        TinTucBUS news = new TinTucBUS();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult get_TinTuc()
        {
            return Json(news.get_TinTuc(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult View_TinTuc(int news)
        {
            return View();
        }
        public JsonResult Details_TinTuc(int id)
        {
            return Json(news.view_TinTuc(id), JsonRequestBehavior.AllowGet);
        }
    }
}