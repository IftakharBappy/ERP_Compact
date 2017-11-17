using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtItemCategoryController : Controller
    {
        // GET: MgtItemCategory
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            ItemCategoryViewModel model = new ItemCategoryViewModel();
            model.ItemCategoryList = db.ItemCategory.Where(a => a.IsDelete == false).Select(x => new ItemCategoryViewModel()
            {
                CategoryKey = x.CategoryKey,
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ItemCategoryViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemCategory model = new ItemCategory();
                    model.CategoryKey = Guid.NewGuid();
                    model.CategoryID = obj.CategoryID;
                    model.CategoryName = obj.CategoryName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.CategoryID)) model.CategoryID = obj.CategoryName;

                    db.ItemCategory.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtItemCategory", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(ItemCategoryViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemCategory model = db.ItemCategory.Find(obj.CategoryKey);
                    model.CategoryID = obj.CategoryID;
                    model.CategoryName = obj.CategoryName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.CategoryID)) model.CategoryID = obj.CategoryName;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtItemCategory", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                ItemCategory model = db.ItemCategory.Find(ID);
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