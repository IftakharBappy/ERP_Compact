using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtItemSubcategoryController : Controller
    {
        // GET: MgtItemSubcategory
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            ItemSubCategoryViewModel model = new ItemSubCategoryViewModel();
            model.ItemSubCategoryList = db.ItemSubcategory.Where(a => a.IsDelete == false).Select(x => new ItemSubCategoryViewModel()
            {
                SubcategoryKey = x.SubcategoryKey,
                SubcategoryID = x.SubcategoryID,
                SubcategoryName = x.SubcategoryName,
                CategoryKey = x.ItemCategory.CategoryKey,
                CategoryName = x.ItemCategory.CategoryName

            }).ToList();

            return View(model);


        }

        [HttpPost]
        public ActionResult Add(ItemSubCategoryViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemSubcategory model = new ItemSubcategory();
                    model.SubcategoryKey = Guid.NewGuid();
                    model.SubcategoryID = obj.SubcategoryID;
                    model.SubcategoryName = obj.SubcategoryName;
                    model.CategoryKey = obj.CategoryKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.SubcategoryID)) model.SubcategoryID = obj.SubcategoryName;

                    db.ItemSubcategory.Add(model);
                    db.SaveChanges();

                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtItemSubcategory", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(ItemSubCategoryViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemSubcategory model = db.ItemSubcategory.Find(obj.SubcategoryKey);
                    model.CategoryKey = obj.CategoryKey;
                    model.SubcategoryID = obj.SubcategoryID;
                    model.SubcategoryName = obj.SubcategoryName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.SubcategoryID)) model.SubcategoryID = obj.SubcategoryName;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtItemSubcategory", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                ItemSubcategory model = db.ItemSubcategory.Find(ID);
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
        public JsonResult LoadItemCategoryDropDown_ToCreate(Guid? id)
        {
            if (id == Guid.Empty || id == null)
            {
                var list = (from st in db.ItemCategory where st.IsDelete == false select new { st.CategoryKey, st.CategoryName, Selected = "" }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = (from st in db.ItemCategory
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
        public JsonResult LoadItemCategorytDropDown_ToEdit(Guid? id)
        {
            var list = (from ItemCategory in db.ItemCategory
                        where ItemCategory.IsDelete == false
                        select new
                        {
                            ItemCategory.CategoryName,
                            ItemCategory.CategoryKey,
                            Selected = ItemCategory.CategoryKey == id ? "selected" : ""
                        }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
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