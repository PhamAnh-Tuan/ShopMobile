using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
using System.Data;
using System.Data.SqlClient;
namespace ShopMobile.Controllers
{
    public class DienThoaiController : Controller
    {
        // GET: DienThoai
        DienThoaiBUS dt = new DienThoaiBUS();
        public ActionResult SearchProduct(string name)
        {
            return View();
        }
        public JsonResult Search_Product(string name)
        {
            return Json(dt.Search_Product(name), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListName(string q)
        {
            return Json(dt.ListName(q), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChiTietSP(int details)
        {
            return View();
        }
        public JsonResult get_chitiet(int details)
        {
            return Json(dt.get_chitiet(details), JsonRequestBehavior.AllowGet);
        }
    }
}