using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    
    public class MgtStoreController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        // GET: MgtStore
        public ActionResult Index()
        {
            AisleViewModel model = new AisleViewModel();
            model.AisleList = db.Aisle.Where(a=>a.IsDelete==false).Select(x => new AisleViewModel()
            {
                                   AisleKey = x.AisleKey,
                                   AisleID = x.AisleID,
                                   AisleName = x.AisleName,
                                   AisleLevel = x.AisleLevel,
                               }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AisleViewModel obj)
        {
                try
                {
                if (ModelState.IsValid)
                {
                    Aisle model = new Aisle();
                    model.AisleKey = Guid.NewGuid();
                    model.AisleName = obj.AisleName;
                    model.AisleID = obj.AisleID;
                    model.AisleLevel = obj.AisleLevel;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.AisleID)) model.AisleID = obj.AisleName;
                    if (obj.AisleLevel == null) { model.AisleLevel = 0; }

                    db.Aisle.Add(model);
                    db.SaveChanges();
                }
                        return Json(obj, JsonRequestBehavior.AllowGet);


                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "MgtStore", "Index"));
                }
            }
        [HttpPost]
        public ActionResult Update(AisleViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Aisle model = db.Aisle.Find(obj.AisleKey);
                    model.AisleName = obj.AisleName;
                    model.AisleID = obj.AisleID;
                    model.AisleLevel = obj.AisleLevel;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.AisleID)) model.AisleID = obj.AisleName;
                    if (obj.AisleLevel == null) { model.AisleLevel = 0; }

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtStore", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
            Aisle model = db.Aisle.Find(ID);
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