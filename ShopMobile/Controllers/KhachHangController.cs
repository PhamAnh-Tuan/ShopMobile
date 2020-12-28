using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
namespace ShopMobile.Controllers
{
    public class KhachHangController : Controller
    {
        KhachHangBUS _db = new KhachHangBUS();
        // GET: KhachHang
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult LoginClient(KhachHang kh)
        {
            var res = _db.Client_Login(kh);
            //Session["User_Client"] = kh.TaiKhoanDangNhap;
            return Json(res);
        }
        public void Register(KhachHang kh)
        {
            _db.Register(kh);
        }
        public ActionResult Logout()
        {
            Session["USER"] = null;
            return RedirectToAction("Index","Home");
        }
        public JsonResult Get_Info(string TK)
        {
            return Json(_db.Get_Info(TK), JsonRequestBehavior.AllowGet);
        }
    }
}