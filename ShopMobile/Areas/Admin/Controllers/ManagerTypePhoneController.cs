using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerTypePhoneController : Controller
    {
        // GET: Admin/ManagerTypePhone
        LoaiDTBUS dblayer = new LoaiDTBUS();
        public ActionResult ManagerTypePhone()
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
        public ActionResult AddTypePhone()
        {
            return View("AddTypePhone");
        }
        public ActionResult UpdateTypePhone(int id)
        {
            return View();
        }
        public JsonResult get_data(int pageindex, int pagesize)
        {
            return Json(dblayer.get_data(pageindex, pagesize), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_LoaiDTbyid(int id)
        {
            return Json(dblayer.Get_LoaiDTbyid(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Register(LoaiDT dt)
        {
            return Json(dblayer.Add_TypePhone(dt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateLoaiDT(LoaiDT dt)
        {
            return Json(dblayer.Update_TypePhone(dt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteLoaiDT(int id)
        {
            return Json(dblayer.Delete_TypePhone(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_LoaiDT()
        {
            return Json(dblayer.Get_LoaiDT(), JsonRequestBehavior.AllowGet);
        }
    }
}