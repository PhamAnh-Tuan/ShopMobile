using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;

namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerNewsController : Controller
    {
        // GET: Admin/ManagerNews
        TinTucBUS ttb = new TinTucBUS();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNews()
        {
            return View();
        }
        public ActionResult UpdateNews(int id)
        {
            return View();
        }
        public JsonResult Get_Paging_TinTuc(int pageindex, int pagesize)
        {
            return Json(ttb.Get_Paging_TinTuc(pageindex, pagesize), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_News_byid(int id)
        {
            return Json(ttb.Get_News_byid(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add_News(TinTuc tt)
        {
            return Json(ttb.Add_News(tt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update_News(TinTuc tt)
        {
            return Json(ttb.Update_News(tt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_News(int id)
        {
            return Json(ttb.Delete_News(id), JsonRequestBehavior.AllowGet);
        }
    }
}