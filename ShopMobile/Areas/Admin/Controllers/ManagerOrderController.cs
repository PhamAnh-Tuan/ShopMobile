using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerOrderController : Controller
    {
        // GET: Admin/ManagerOrder
        DonHangBUS _db = new DonHangBUS();
        public ActionResult OrderNotComfirm()
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
        public ActionResult OrderComfirm()
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
        public ActionResult OrderDelivered()
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
        public JsonResult Get_Paging_DonHangChuaXacThuc(int pageindex,int pagesize)
        {
            return Json(_db.Get_Paging_DonHangChuaXacThuc(pageindex, pagesize),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Paging_DonHangDaXacThuc(int pageindex, int pagesize)
        {
            return Json(_db.Get_Paging_DonHangDaXacThuc(pageindex, pagesize),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Paging_DonHangDaGiao(int pageindex, int pagesize)
        {
            return Json(_db.Get_Paging_DonHangDaGiao(pageindex, pagesize),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Comfirm_ThisOrder(string value)
        {
            return Json(_db.Comfirm_ThisOrder(value), JsonRequestBehavior.AllowGet);
        }
        public JsonResult View_Details(string value)
        {
            return Json(_db.View_Details(value), JsonRequestBehavior.AllowGet);
        }
    }
}