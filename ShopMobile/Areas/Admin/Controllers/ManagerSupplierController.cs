using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;

namespace ShopMobile.Areas.Admin.Controllers
{
    public class ManagerSupplierController : Controller
    {
        // GET: Admin/ManagerSupplier
        NhaCungCapBUS ncc = new NhaCungCapBUS();
        public ActionResult Index()
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
        public JsonResult Get_Paging_Supplier(int pagesize, int pageindex)
        {
            return Json(ncc.Get_Paging_Supplier(pagesize, pageindex), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddSupplier()
        {
            return View();
        }
        public JsonResult Add_Supplier(NhaCungCap supp)
        {
            return Json(ncc.Add_Supplier(supp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_Supplier(int id)
        {
            return Json(ncc.Delete_Supplier(id), JsonRequestBehavior.AllowGet);
        }
    }
}