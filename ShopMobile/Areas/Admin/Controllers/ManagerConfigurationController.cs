using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerConfigurationController : Controller
    {
        // GET: Admin/ManagerConfiguration
        CauHinhBUS ch = new CauHinhBUS();
        DienThoaiBUS dtb = new DienThoaiBUS();
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
        public ActionResult AddConfiguration()
        {
            return View();
        }
        public ActionResult UpdateConfiguration(int id)
        {
            return View();
        }
        public JsonResult Get_DienThoai_Data()
        {
            return Json(dtb.Get_DienThoai_Data(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Paging_Confi(int pagesize, int pageindex)
        {
            return Json(ch.Get_Paging_Confi(pagesize, pageindex), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Add_Configuration(CauHinh c)
        {
            return Json(ch.Add_Configuration(c), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Configuration_ByID(int MaCauHinh)
        {
            return Json(ch.Get_Configuration_ByID(MaCauHinh), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update_Configuration(CauHinh c)
        {
            return Json(ch.Update_Configuration(c), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_Configuration(int MaCauHinh)
        {
            return Json(ch.Delete_Configuration(MaCauHinh), JsonRequestBehavior.AllowGet);
        }
    }
}