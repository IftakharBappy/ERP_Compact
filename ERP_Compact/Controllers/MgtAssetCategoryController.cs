using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtAssetCategoryController : Controller
    {
        // GET: MgtAssetCategory
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            AssetCategoryViewModel model = new AssetCategoryViewModel();
            model.AssetCategoryList = db.AssetCategory.Where(a => a.IsDelete == false).Select(x => new AssetCategoryViewModel()
            {
                CategoryKey = x.CategoryKey,
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AssetCategoryViewModel obj)
        {
            try
            {
                AssetCategory model = new AssetCategory();
                model.CategoryKey = Guid.NewGuid();
                model.CategoryID = obj.CategoryID;
                model.CategoryName = obj.CategoryName;
                model.IsDelete = false;
                if (string.IsNullOrEmpty(obj.CategoryID)) model.CategoryID = obj.CategoryName;

                db.AssetCategory.Add(model);
                db.SaveChanges();

                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtAssetCategory", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(AssetCategoryViewModel obj)
        {
            try
            {
                AssetCategory model = db.AssetCategory.Find(obj.CategoryKey);
                model.CategoryID = obj.CategoryID;
                model.CategoryName = obj.CategoryName;
                model.IsDelete = false;
                if (string.IsNullOrEmpty(obj.CategoryID)) model.CategoryID = obj.CategoryName;

                db.SaveChanges();

                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtAssetCategory", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                AssetCategory model = db.AssetCategory.Find(ID);
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
    }
}