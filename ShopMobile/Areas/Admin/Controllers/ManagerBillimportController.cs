using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;
namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerBillimportController : Controller
    {
        HoaDonNhapBUS hdb = new HoaDonNhapBUS();
        // GET: Admin/ManagerBillimport
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get_Paging_HoaDonNhap(int pageindex, int pagesize)
        {
            return Json(hdb.Get_Paging_HoaDonNhap(pageindex,pagesize), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddBill()
        {
            return View();
        }
        public JsonResult Add_Bill(HoaDonNhap hd)
        {
            return Json(hdb.Add_Bill(hd), JsonRequestBehavior.AllowGet);
        }
    }
}