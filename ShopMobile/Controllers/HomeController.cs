using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

using DTO;
using BUS;
namespace ShopMobile.Controllers
{
    public class HomeController : Controller
    {
        LoaiDTBUS dblayer = new LoaiDTBUS();
        DienThoaiBUS dbDT = new DienThoaiBUS();
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }
        public JsonResult Get_LoaiDT()
        {
            return Json(dblayer.Get_LoaiDT(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_DienThoai10()
        {
            return Json(dbDT.Get_DienThoai10(), JsonRequestBehavior.AllowGet);
        }       
    }
}