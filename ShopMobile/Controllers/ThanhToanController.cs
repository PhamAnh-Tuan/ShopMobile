using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
namespace ShopMobile.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        DonHangBUS dhb = new DonHangBUS();
        public ActionResult Index()
        {
            return View();
        }
        public void Add_DonHang(DonHang dh)
        {
            dhb.Add_DonHang(dh);
        }
        public void Add_ChiTietDonHang(ChiTietDonHang dh)
        {
            dhb.Add_ChiTietDonHang(dh);
        }
    }
}