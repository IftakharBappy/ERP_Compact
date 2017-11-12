﻿using System;
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