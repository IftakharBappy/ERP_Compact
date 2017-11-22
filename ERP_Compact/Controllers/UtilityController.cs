using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP_Compact.Models;
using Newtonsoft.Json;
using ERP_Compact.DAL;
using System.Text;


namespace ERP_Compact.Controllers
{
    public class UtilityController : Controller
    {
        // GET: Utility
        private ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult LoadDivision(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            GISclass obj = new GISclass();
            Division m = db.Division.Find(SelectID);
            obj.DivisionKey = m.DivisionKey;
            obj.DivisionID = m.DivisionID;
            obj.DivisionName = m.DivisionName;

            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadAisle(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            AisleViewModel obj = new AisleViewModel();
            Aisle m = db.Aisle.Find(SelectID);
            obj.AisleKey = m.AisleKey;
            obj.AisleID = m.AisleID;
            obj.AisleName = m.AisleName;
            obj.AisleLevel = m.AisleLevel;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadAssetCategory(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            AssetCategoryViewModel obj = new AssetCategoryViewModel();
            AssetCategory m = db.AssetCategory.Find(SelectID);
            obj.CategoryKey = m.CategoryKey;
            obj.CategoryID = m.CategoryID;
            obj.CategoryName = m.CategoryName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult LoadDepartmentView(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            DepartmentViewModel obj = new DepartmentViewModel();
            Department m = db.Department.Find(SelectID);
            obj.DepartmentKey = m.DepartmentKey;
            obj.DepartmentID = m.DepartmentID;
            obj.DepartmentName = m.DepartmentName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult LoadAssetSubCategory(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            AssetSubcategoryViewModel obj = new AssetSubcategoryViewModel();
            AssetSubcategory m = db.AssetSubcategory.Find(SelectID);
            obj.CategoryKey = m.CategoryKey;
            obj.SubcategoryKey = m.SubcategoryKey;
            obj.SubcategoryID = m.SubcategoryID;
            obj.SubcategoryName = m.SubcategoryName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadDesignation(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            DesignationViewModel obj = new DesignationViewModel();
            Designation m = db.Designation.Find(SelectID);
            obj.DesignationKey = m.DesignationKey;
            obj.DesignationtID = m.DesignationtID;
            obj.DesignationName = m.DesignationName;
            obj.DesignationLevel = m.DesignationLevel;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult LoadDistrict(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            DistrictViewModel obj = new DistrictViewModel();
            District m = db.District.Find(SelectID);
            obj.DistrictKey = m.DistrictKey;
            obj.DistrictID = m.DistrictID;
            obj.DistrictName = m.DistrictName;
            obj.DivisionKey = m.DivisionKey;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadForms(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            FormsViewModel obj = new FormsViewModel();
            Forms m = db.Forms.Find(SelectID);
            obj.FormID = m.FormID;
            obj.ModuleID = m.ModuleID;
            obj.SubModuleID = m.SubModuleID;
            obj.FormName = m.FormName;
            obj.FormLevel = m.FormLevel;
            obj.FormController = m.FormController;
            obj.ViewName = m.ViewName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult LoadItemCategory(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            ItemCategoryViewModel obj = new ItemCategoryViewModel();
            ItemCategory m = db.ItemCategory.Find(SelectID);
            obj.CategoryKey = m.CategoryKey;
            obj.CategoryID = m.CategoryID;
            obj.CategoryName = m.CategoryName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadItemSubCategory(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            ItemSubCategoryViewModel obj = new ItemSubCategoryViewModel();
            ItemSubcategory m = db.ItemSubcategory.Find(SelectID);
            obj.CategoryKey = m.CategoryKey;
            obj.SubcategoryKey = m.SubcategoryKey;
            obj.SubcategoryID = m.SubcategoryID;
            obj.SubcategoryName = m.SubcategoryName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadItemType(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            ItemTypeViewModel obj = new ItemTypeViewModel();
            ItemType m = db.ItemType.Find(SelectID);
            obj.TypeKey = m.TypeKey;
            obj.TypeID = m.TypeID;
            obj.TypeName = m.TypeName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult LoadModule(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            ModulesViewModel obj = new ModulesViewModel();
            Modules m = db.Modules.Find(SelectID);
            obj.ModuleID = m.ModuleID;
            obj.ModuleName = m.ModuleName;
            obj.ModuleLevel = m.ModuleLevel;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadProductionProcessSetup(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            ProductionProcessSetupViewModel obj = new ProductionProcessSetupViewModel();
            ProductionProcessSetup m = db.ProductionProcessSetup.Find(SelectID);
            obj.ProcessKey = m.ProcessKey;
            obj.ProcessID = m.ProcessID;
            obj.ProcessName = m.ProcessName;
            obj.ProcessLevel = m.ProcessLevel;
            obj.Description = m.Description;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadStoreRows(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            StoreRowsViewModel obj = new StoreRowsViewModel();
            Row_Store m = db.Row_Store.Find(SelectID);
            obj.RowKey = m.RowKey;
            obj.RowID = m.RowID;
            obj.RowName = m.RowName;
            obj.RowLevel = m.RowLevel;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadStoreShelf(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            StoreShelfViewModel obj = new StoreShelfViewModel();
            Shelf m = db.Shelf.Find(SelectID);
            obj.ShelfKey = m.ShelfKey;
            obj.ShelfID = m.ShelfID;
            obj.ShelfName = m.ShelfName;
            obj.ShelfLevel = m.ShelfLevel;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult LoadSubModule(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            SubModuleViewModel obj = new SubModuleViewModel();
            SubModule m = db.SubModule.Find(SelectID);
            obj.SubModuleID = m.SubModuleID;
            obj.ModuleID = m.ModuleID;
            obj.SubModuleName = m.SubModuleName;
            obj.SubModuleLevel = m.SubModuleLevel;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadTax(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            TaxViewModel obj = new TaxViewModel();
            Tax m = db.Tax.Find(SelectID);
            obj.TaxKey = m.TaxKey;
            obj.TaxID = m.TaxID;
            obj.Amt = m.Amt;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult LoadUnit(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            UnitViewModel obj = new UnitViewModel();
            Unit m = db.Unit.Find(SelectID);
            obj.UnitKey = m.UnitKey;
            obj.UnitID = m.UnitID;
            obj.UnitName = m.UnitName;
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public JsonResult GetDistrictsOfDivision (Guid divisionKey)
        {
            var res = db.District.Where(d => d.DivisionKey == divisionKey && d.IsDelete == false).Select( x=> new { x.DistrictKey, x.DistrictName }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUpazillasOfDistrict(Guid districtKey)
        {
            var res = db.Upazilla.Where(d => d.DistrictKey == districtKey && d.IsDelete == false).Select(x => new { x.UpazillaKey, x.UpazillaName }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
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