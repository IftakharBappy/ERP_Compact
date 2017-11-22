using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtStoreRawsController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        // GET: MgtStoreRaws
        public ActionResult Index()
        {
            StoreRowsViewModel model = new StoreRowsViewModel();
            model.StoreRowsList = db.Row_Store.Where(a => a.IsDelete == false).Select(x => new StoreRowsViewModel()
            {
                RowKey = x.RowKey,
                RowID = x.RowID,
                RowName = x.RowName,
                RowLevel = x.RowLevel,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(StoreRowsViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Row_Store model = new Row_Store();
                    model.RowKey = Guid.NewGuid();
                    model.RowID = obj.RowID;
                    model.RowName = obj.RowName;
                    model.RowLevel = obj.RowLevel;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.RowID)) model.RowID = obj.RowName;

                    db.Row_Store.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtStoreRaws", "Index"));
            }
        }

        [HttpPost]
        public ActionResult Update(StoreRowsViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Row_Store model = db.Row_Store.Find(obj.RowKey);
                    model.RowID = obj.RowID;
                    model.RowName = obj.RowName;
                    model.RowLevel = obj.RowLevel;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.RowID)) model.RowID = obj.RowName;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtStoreRaws", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                Row_Store model = db.Row_Store.Find(ID);
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