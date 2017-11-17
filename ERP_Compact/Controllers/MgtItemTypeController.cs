using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtItemTypeController : Controller
    {
        // GET: MgtItemType
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            ItemTypeViewModel model = new ItemTypeViewModel();
            model.ItemTypeList = db.ItemType.Where(a => a.IsDelete == false).Select(x => new ItemTypeViewModel()
            {
                TypeKey = x.TypeKey,
                TypeName = x.TypeName,
                TypeID = x.TypeID,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ItemTypeViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemType model = new ItemType();
                    model.TypeKey = Guid.NewGuid();
                    model.TypeID = obj.TypeID;
                    model.TypeName = obj.TypeName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.TypeID)) model.TypeID = obj.TypeName;

                    db.ItemType.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtItemType", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(ItemTypeViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemType model = db.ItemType.Find(obj.TypeKey);
                    model.TypeID = obj.TypeID;
                    model.TypeName = obj.TypeName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.TypeID)) model.TypeID = obj.TypeName;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtItemType", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                ItemType model = db.ItemType.Find(ID);
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