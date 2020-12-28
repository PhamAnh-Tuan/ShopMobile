using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerPhoneController : Controller
    {
        DienThoaiBUS _db = new DienThoaiBUS();
        // GET: Admin/ManagerPhone
        public ActionResult ManagerPhone()
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
        public ActionResult AddPhone()
        {
            return View();
        }
        public ActionResult UpdatePhone(int id)
        {
            return View();
        }
        public JsonResult Get_Paging_DienThoai(int pageindex,int pagesize)
        {
            return Json(_db.Get_Paging_DienThoai(pageindex, pagesize), JsonRequestBehavior.AllowGet);
        }
        public void Register(DienThoai dt)
        {
            _db.Add_Phone(dt);
        }       
        public JsonResult Update_DienThoai(DienThoai dt)
        {
            return Json(_db.Update_Phone(dt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_DienThoai(int id)
        {
            return Json(_db.Delete_Phone(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_DienThoai_byid(int id)
        {
            return Json(_db.Get_DienThoai_byid(id), JsonRequestBehavior.AllowGet);
        }
    }
}