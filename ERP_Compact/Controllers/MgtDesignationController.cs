using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtDesignationController : Controller
    {
        // GET: MgtDesignation
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            DesignationViewModel model = new DesignationViewModel();
            model.DesignationList = db.Designation.Where(a => a.IsDelete == false).Select(x => new DesignationViewModel()
            {
                DesignationKey = x.DesignationKey,
                DesignationtID = x.DesignationtID,
                DesignationName = x.DesignationName,
                DesignationLevel = x.DesignationLevel,

            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(DesignationViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Designation model = new Designation();
                    model.DesignationKey = Guid.NewGuid();
                    model.DesignationtID = obj.DesignationtID;
                    model.DesignationName = obj.DesignationName;
                    model.DesignationLevel = obj.DesignationLevel;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.DesignationtID)) model.DesignationtID = obj.DesignationName;
                    if (obj.DesignationLevel == null) { model.DesignationLevel = 0; }
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    db.Designation.Add(model);
                    db.SaveChanges();

                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtDesignation", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(DesignationViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Designation model = db.Designation.Find(obj.DesignationKey);
                    model.DesignationtID = obj.DesignationtID;
                    model.DesignationName = obj.DesignationName;
                    model.DesignationLevel = obj.DesignationLevel;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.DesignationtID)) model.DesignationtID = obj.DesignationName;
                    if (obj.DesignationLevel == null) { model.DesignationLevel = 0; }
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtDesignation", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                Designation model = db.Designation.Find(ID);
                model.IsDelete = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch
            {
                ModelState.AddModelError(string.Empty, "Some error happened");
                return View(ID);
            }
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