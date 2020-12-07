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
        [HttpPost]
        public JsonResult AddCart(DienThoai s)
        {
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<ChiTietDonHang>();
            }
            List<ChiTietDonHang> giohang = Session["giohang"] as List<ChiTietDonHang>;
            ChiTietDonHang d = null;

            if (giohang.Find(m => m.MaCauHinh == s.MaCauHinh) == null)
            {
                d = new ChiTietDonHang();
                d.MaCauHinh = s.MaCauHinh;
                d.DonGia = s.Gia;
                d.SoLuong = 1;
                giohang.Add(d);
            }
            else
            {
                giohang.Find(m => m.MaCauHinh == s.MaCauHinh).SoLuong = giohang.Find(m => m.MaCauHinh == s.MaCauHinh).SoLuong + 1;
            }
            int soluong = 0;
            foreach (ChiTietDonHang c in giohang)
            {

                soluong = soluong + c.SoLuong;
            }
            return Json(new { ctdon = d, sl = soluong }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCarts()
        {
            int sl = 0;
            int thanhtien = 0;
            List<ChiTietDonHang> ds = new List<ChiTietDonHang>();
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<ChiTietDonHang>();
                sl = 0;
                thanhtien = 0;
            }
            else
            {
                ds = Session["giohang"] as List<ChiTietDonHang>;
                thanhtien = ds.Sum(s => s.DonGia * s.SoLuong);
                sl = ds.Sum(s => s.SoLuong);
            }
            return Json(new { DSDonHang = ds, soluong = sl, ThanhTien = thanhtien }, JsonRequestBehavior.AllowGet);
        }
    }
}