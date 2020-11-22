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
        public ActionResult Search(string key)
        {
            return View();
        }
        public JsonResult ListName(string q)
        {
            return Json(dt.ListName(q), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChiTietSP(int details)
        {
            Session.Add("details", details);
            return View();
        }
        public JsonResult get_chitiet()
        {
            return Json(dt.get_chitiet(Convert.ToInt32(Session["details"].ToString())), JsonRequestBehavior.AllowGet);
        }
    }
}