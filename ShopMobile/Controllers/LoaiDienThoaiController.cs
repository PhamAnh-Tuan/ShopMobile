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
    public class LoaiDienThoaiController : Controller
    {
        // GET: LoaiDienThoai
        LoaiDTBUS dblayer = new LoaiDTBUS();
        DienThoaiBUS dbDT = new DienThoaiBUS();
        public ActionResult Index(string maloai)
        {
            Session.Add("maloai", maloai);
            return View();
        }

        public JsonResult Get_DienThoai_byMaLoai()
        {
            return Json(dbDT.Get_DienThoai_byMaLoai(Session["maloai"].ToString()), JsonRequestBehavior.AllowGet);
        }
    }
}