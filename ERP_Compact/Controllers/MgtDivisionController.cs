using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP_Compact.Models;
using ERP_Compact.DAL;
namespace ERP_Compact.Controllers
{
    public class MgtDivisionController : Controller
    {
        // GET: MgtDivision
        ERPMgtEntities db = new ERPMgtEntities();
        ManageGIS manage = new ManageGIS();
        public ActionResult Index()
        {
            try
            {
                GISclass obj = new GISclass();
                obj.ModuleList = new List<GISclass>();
                obj.ModuleList = manage.ListAll();
                return View(obj);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));
            }

        }
        public JsonResult Add(GISclass model)
        {
            return Json(manage.Add(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(GISclass model)
        {
            return Json(manage.Update(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Guid ID)
        {
            return Json(manage.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}