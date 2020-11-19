using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
namespace ShopMobile.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public JsonResult AddCart(DienThoai s)
        //{
        //    if (Session["giohang"] == null)
        //    {
        //        Session["giohang"] = new List<ChiTietDonHang>();
        //    }
        //}
    }
}