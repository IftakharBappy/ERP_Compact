using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtStoreShelfController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        // GET: MgtStoreShelf
        public ActionResult Index()
        {
            StoreShelfViewModel model = new StoreShelfViewModel();
            model.StoreShelfList = db.Shelf.Where(a => a.IsDelete == false).Select(x => new StoreShelfViewModel()
            {
                ShelfKey = x.ShelfKey,
                ShelfID = x.ShelfID,
                ShelfName = x.ShelfName,
                ShelfLevel = x.ShelfLevel,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(StoreShelfViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Shelf model = new Shelf();
                    model.ShelfKey = Guid.NewGuid();
                    model.ShelfID = obj.ShelfID;
                    model.ShelfName = obj.ShelfName;
                    model.ShelfLevel = obj.ShelfLevel;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.ShelfID)) model.ShelfID = obj.ShelfName;

                    db.Shelf.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtStoreShelf", "Index"));
            }
        }

        [HttpPost]
        public ActionResult Update(StoreShelfViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Shelf model = db.Shelf.Find(obj.ShelfKey);
                    model.ShelfID = obj.ShelfID;
                    model.ShelfName = obj.ShelfName;
                    model.ShelfLevel = obj.ShelfLevel;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.ShelfID)) model.ShelfID = obj.ShelfName;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtStoreShelf", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                Shelf model = db.Shelf.Find(ID);
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