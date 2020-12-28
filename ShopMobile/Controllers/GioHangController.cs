using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
namespace ShopMobile.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        GioHangBUS ghb = new GioHangBUS();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThanhToan()
        {
            return View();
        }
        public JsonResult Get_Cart(int MaKhach)
        {
            return Json(ghb.Get_Cart(MaKhach), JsonRequestBehavior.AllowGet);
        }
        public void Cart_ASC(string MaCT)
        {
            ghb.Cart_ASC(MaCT);
        }
        public void Cart_DESC(string MaCT)
        {
            ghb.Cart_DESC(MaCT);
        }
        public void Add_To_Cart(int MaKhachHang, int MaCauHinh, int DonGia, int SoLuong)
        {
            ghb.Add_To_Cart(MaKhachHang,MaCauHinh,DonGia,SoLuong);
        }
        public void DELETE_PRODUCTCART(string MaCT)
        {
            ghb.DELETE_PRODUCTCART(MaCT);
        }
    }
}