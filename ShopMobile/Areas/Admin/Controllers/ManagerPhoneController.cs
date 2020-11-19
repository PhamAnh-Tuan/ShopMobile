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
        DienThoaiBUS dblayer = new DienThoaiBUS();
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
            return Json(dblayer.Get_Paging_DienThoai(pageindex, pagesize), JsonRequestBehavior.AllowGet);
        }
        public void Register(DienThoai dt)
        {
            dblayer.Add_Phone(dt);
        }
        [HttpGet]
        
        public JsonResult Update_DienThoai(DienThoai dt)
        {
            return Json(dblayer.Update_Phone(dt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_DienThoai(int id)
        {
            return Json(dblayer.Delete_Phone(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_DienThoai_byid(int id)
        {
            return Json(dblayer.Get_DienThoai_byid(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Upload(string anh)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~Assets/Client/img/product/" + anh + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach(string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                pf.SaveAs(path + pf.FileName);
                l.Add(pf.FileName);
            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}