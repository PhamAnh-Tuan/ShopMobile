using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerBillDetailsController : Controller
    {
        HoaDonNhapBUS hdb = new HoaDonNhapBUS();
        CTHoaDonNhapBUS dblayer = new CTHoaDonNhapBUS();
        CauHinhBUS chb = new CauHinhBUS();
        // GET: Admin/ManagerBillDetails
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddBillDetails()
        {
            return View();
        }
        public ActionResult UpdateBillDetails(int id)
        {
            return View();
        }
        
        public JsonResult Get_Paging_CTHoaDonNhap(int pageindex, int pagesize)
        {
            return Json(dblayer.Get_Paging_CTHoaDonNhap(pageindex, pagesize), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GET_BillDetails_ID(int id)
        {
            return Json(dblayer.GET_BillDetails_ID(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add_BillDetails(CTHoaDonNhap ct)
        {
            return Json(dblayer.Add_BillDetails(ct), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update_BillDetails(CTHoaDonNhap ct)
        {
            return Json(dblayer.Update_BillDetails(ct), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_BillDetails(int id)
        {
            return Json(dblayer.Delete_BillDetails(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_CauHinh()
        {
            return Json(chb.Get_CauHinh(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_HoaDonNhap()
        {
            return Json(hdb.Get_HoaDonNhap(), JsonRequestBehavior.AllowGet);
        }
    }
}