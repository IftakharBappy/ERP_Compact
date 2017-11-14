using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtAssetSubcategoryController : Controller
    {
        // GET: MgtAssetSubcategory
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            AssetSubcategoryViewModel model = new AssetSubcategoryViewModel();
            model.AssetSubcategoryList = db.AssetSubcategory.Where(a => a.IsDelete == false).Select(x => new AssetSubcategoryViewModel()
            {
                SubcategoryKey = x.SubcategoryKey,
                SubcategoryID = x.SubcategoryID,
                SubcategoryName = x.SubcategoryName,
                CategoryKey = x.AssetCategory.CategoryKey,
                CategoryName = x.AssetCategory.CategoryName

            }).ToList();

            return View(model);


        }

        [HttpPost]
        public ActionResult Add(AssetSubcategoryViewModel obj)
        {
            try
            {
                AssetSubcategory model = new AssetSubcategory();
                model.SubcategoryKey = Guid.NewGuid();
                model.SubcategoryID = obj.SubcategoryID;
                model.SubcategoryName = obj.SubcategoryName;
                model.CategoryKey = obj.CategoryKey;
                model.IsDelete = false;
                if (string.IsNullOrEmpty(obj.SubcategoryID)) model.SubcategoryID = obj.SubcategoryName;

                db.AssetSubcategory.Add(model);
                db.SaveChanges();

                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtAssetSubcategory", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(AssetSubcategoryViewModel obj)
        {
            try
            {
                AssetSubcategory model = db.AssetSubcategory.Find(obj.SubcategoryKey);
                model.CategoryKey = obj.CategoryKey;
                model.SubcategoryID = obj.SubcategoryID;
                model.SubcategoryName = obj.SubcategoryName;
                model.IsDelete = false;
                if (string.IsNullOrEmpty(obj.SubcategoryID)) model.SubcategoryID = obj.SubcategoryName;

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
                AssetSubcategory model = db.AssetSubcategory.Find(ID);
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
        public JsonResult LoadCategoryDropDown_ToCreate(Guid? id)
        {
            if (id == Guid.Empty || id == null)
            {
                var list = (from st in db.AssetCategory where st.IsDelete == false select new { st.CategoryKey, st.CategoryName, Selected = "" }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = (from st in db.AssetCategory
                            where st.IsDelete == false
                            select new
                            {
                                st.CategoryKey,
                                st.CategoryName,
                                Selected = st.CategoryKey == id ? "selected" : ""
                            }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LoadCategorytDropDown_ToEdit(Guid? id)
        {
            var list = (from AssetCategory in db.AssetCategory
                        where AssetCategory.IsDelete == false
                        select new
                        {
                            AssetCategory.CategoryName,
                            AssetCategory.CategoryKey,
                            Selected = AssetCategory.CategoryKey == id ? "selected" : ""
                        }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}