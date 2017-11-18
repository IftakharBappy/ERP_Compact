using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtProductionProcessSetupController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        // GET: MgtProductionProcessSetup
        public ActionResult Index()
        {
            ProductionProcessSetupViewModel model = new ProductionProcessSetupViewModel();
            model.ProductionProcessSetupList = db.ProductionProcessSetup.Where(a => a.IsDelete == false).Select(x => new ProductionProcessSetupViewModel()
            {
                ProcessKey = x.ProcessKey,
                ProcessID = x.ProcessID,
                ProcessName = x.ProcessName,
                ProcessLevel = x.ProcessLevel,
                Description = x.Description,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ProductionProcessSetupViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductionProcessSetup model = new ProductionProcessSetup();
                    model.ProcessKey = Guid.NewGuid();
                    model.ProcessID = obj.ProcessID;
                    model.ProcessName = obj.ProcessName;
                    model.ProcessLevel = obj.ProcessLevel;
                    model.Description = obj.Description;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.ProcessID)) model.ProcessID = obj.ProcessName;
                    if (obj.Description == null) { model.Description = "N/A"; }

                    db.ProductionProcessSetup.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtProductionProcessSetup", "Index"));
            }
        }

        [HttpPost]
        public ActionResult Update(ProductionProcessSetupViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductionProcessSetup model = db.ProductionProcessSetup.Find(obj.ProcessKey);
                    model.ProcessID = obj.ProcessID;
                    model.ProcessName = obj.ProcessName;
                    model.ProcessLevel = obj.ProcessLevel;
                    model.Description = obj.Description;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.ProcessID)) model.ProcessID = obj.ProcessName;
                    if (obj.Description == null) { model.Description = "N/A"; }

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtProductionProcessSetup", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                ProductionProcessSetup model = db.ProductionProcessSetup.Find(ID);
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