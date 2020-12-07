using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
using System.Data;
namespace ShopMobile.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        AdminBUS _db = new AdminBUS();

        public ActionResult Login()//quay lại cái kia đi
        {
            return View();
        }
        public JsonResult LoginAdmin(DTO.Admin ad)
        {
            var res = _db.Admin_Login(ad);
            Session["USER"] = res.TaiKhoan;
            return Json(res);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session["USER"] = null;
            return View("Login");
        }
    }
}