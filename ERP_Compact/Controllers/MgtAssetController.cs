using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP_Compact.Models;

namespace ERP_Compact.Controllers
{
    public class MgtAssetController : BaseController
    {
        // GET: MgtAsset
        public ActionResult Index()
        {
            var list = db.Asset.Where(a => a.IsDelete == false).Select(model =>
            new AssetViewModel()
            {
                ItemKey = model.ItemKey,
                ItemID = model.ItemID,
                ItemName = model.ItemName,
                ModelNo = model.ModelNo,
                AssetCategoryName = model.CategoryKey != null ? db.AssetCategory.Where(c => c.CategoryKey == model.CategoryKey).Select(c => c.CategoryName).FirstOrDefault() : "n/a"
            }
            ).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName");//# todo manage properly
            ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName");// to send and empty list
            ViewBag.ManufacturerKey = new SelectList(db.Manufacturer, "ManufacturerKey", "ManufacturerName");// to send and empty list
            ViewBag.UnitKey = new SelectList(db.Unit.Where(x=>x.IsDelete==false), "UnitKey", "UnitID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Logo")] AssetViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new Asset();
                    model.IsDelete = false;
                    model.ItemKey = Guid.NewGuid();

                    model.ItemName = viewModel.ItemName;
                    model.ItemID = viewModel.ItemID;
                    model.Description = string.IsNullOrEmpty(viewModel.Description) ? "n/a" : viewModel.Description;
                    model.ProductID = string.IsNullOrEmpty(viewModel.ProductID) ? viewModel.ItemID : viewModel.ProductID;
                    model.UnitKey = viewModel.UnitKey;
                    model.CategoryKey = viewModel.CategoryKey;
                    model.SubcategoryKey = viewModel.SubcategoryKey;
                    //model.TypeKey = viewModel.TypeKey; #todo not available in db.model
                    model.ModelNo = string.IsNullOrEmpty(viewModel.ModelNo) ? "n/a" : viewModel.ModelNo;
                    model.ItemColor = string.IsNullOrEmpty(viewModel.ItemColor) ? "n/a" : viewModel.ItemColor;
                    model.ReorderLevel = viewModel.ReorderLevel == null ? 1 : viewModel.ReorderLevel;

                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.logo = imgBinaryData;
                    model.Logotype = Logo.ContentType;

                    model.ManufacturerKey = viewModel.ManufacturerKey;
                    model.StartYear = viewModel.StartYear == null ? DateTime.Now.Year : viewModel.StartYear;
                    model.DepreciationFactor = viewModel.DepreciationFactor == null ? 1 : viewModel.DepreciationFactor;
                    model.AssetLife = viewModel.AssetLife == null ? 1 : viewModel.AssetLife;



                    db.Asset.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Asset is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Asset could not be created due to an error.");
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName");//# todo manage properly
                ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName");//# todo manage properly
                ViewBag.ManufacturerKey = new SelectList(db.Manufacturer, "ManufacturerKey", "ManufacturerName");//# todo manage properly
                ViewBag.UnitKey = new SelectList(db.Unit.Where(x => x.IsDelete == false), "UnitKey", "UnitID", viewModel.UnitKey);
                return View(viewModel);
            }

        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.Asset.Where(x => x.ItemKey == id).Select(model => new AssetViewModel()
            {
                ItemKey = model.ItemKey,
                ItemName = model.ItemName,
                ItemID = model.ItemID,
                Description = model.Description,
                ProductID = model.ProductID,
                UnitKey = model.UnitKey,
                CategoryKey = model.CategoryKey,
                SubcategoryKey = model.SubcategoryKey,
                ModelNo = model.ModelNo,
                ItemColor = model.ItemColor,
                ReorderLevel = model.ReorderLevel,
                Logo = model.logo,
                Logotype = model.Logotype,
                ManufacturerKey = model.ManufacturerKey,
                StartYear = model.StartYear,
                DepreciationFactor = model.DepreciationFactor,
                AssetLife = model.AssetLife,
            }).FirstOrDefault();

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName", viewModel.CategoryKey);//# todo manage properly
            ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName", viewModel.SubcategoryKey);//# todo manage properly
            ViewBag.ManufacturerKey = new SelectList(db.Manufacturer, "ManufacturerKey", "ManufacturerName", viewModel.ManufacturerKey);//# todo manage properly
            ViewBag.UnitKey = new SelectList(db.Unit.Where(x => x.IsDelete == false), "UnitKey", "UnitID", viewModel.UnitKey);


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Logo")] AssetViewModel viewModel, HttpPostedFileBase Logo)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.Asset.Where(x => x.ItemKey == viewModel.ItemKey).FirstOrDefault();

                    model.ItemName = viewModel.ItemName;
                    model.ItemID = viewModel.ItemID;
                    model.Description = string.IsNullOrEmpty(viewModel.Description) ? "n/a" : viewModel.Description;
                    model.ProductID = string.IsNullOrEmpty(viewModel.ProductID) ? viewModel.ItemID : viewModel.ProductID;
                    model.UnitKey = viewModel.UnitKey;
                    model.CategoryKey = viewModel.CategoryKey;
                    model.SubcategoryKey = viewModel.SubcategoryKey;
                    //model.TypeKey = viewModel.TypeKey; # todo not available in db.model
                    model.ModelNo = string.IsNullOrEmpty(viewModel.ModelNo) ? "n/a" : viewModel.ModelNo;
                    model.ItemColor = string.IsNullOrEmpty(viewModel.ItemColor) ? "n/a" : viewModel.ItemColor;
                    model.ReorderLevel = viewModel.ReorderLevel == null ? 1 : viewModel.ReorderLevel;

                    if (viewModel.KeepOldLogo == false)
                    {
                        byte[] imgBinaryData = new byte[Logo.ContentLength];
                        int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                        model.logo = imgBinaryData;
                        model.Logotype = Logo.ContentType;
                    }

                    model.ManufacturerKey = viewModel.ManufacturerKey;
                    model.StartYear = viewModel.StartYear == null ? DateTime.Now.Year : viewModel.StartYear;
                    model.DepreciationFactor = viewModel.DepreciationFactor == null ? 1 : viewModel.DepreciationFactor;
                    model.AssetLife = viewModel.AssetLife == null ? 1 : viewModel.AssetLife;

                    db.SaveChanges();

                    RenderSuccessMessage("Asset is successfully updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Asset could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.UnitKey });
                }
            }
            else
            {

                ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName", viewModel.CategoryKey);
                ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName", viewModel.SubcategoryKey);// to send and empty list
                ViewBag.ManufacturerKey = new SelectList(db.Manufacturer, "ManufacturerKey", "ManufacturerName", viewModel.ManufacturerKey);// to send and empty list
                ViewBag.UnitKey = new SelectList(db.Unit, "UnitKey", "UnitID", viewModel.UnitKey);// to send and empty list

                RenderInfoMessage("Please, provide all required data.");
                return View(viewModel);
            }

        }


        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Asset.Where(x => x.ItemKey == id).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new AssetViewModel()
                {
                    ItemKey = model.ItemKey,
                    ItemName = model.ItemName,
                    ItemID = model.ItemID,
                    Description = model.Description,
                    ProductID = model.ProductID,
                    UnitKey = model.UnitKey,
                    CategoryKey = model.CategoryKey,
                    SubcategoryKey = model.SubcategoryKey,
                    ModelNo = model.ModelNo,
                    ItemColor = model.ItemColor,
                    ReorderLevel = model.ReorderLevel,
                    Logo = model.logo,
                    Logotype = model.Logotype,
                    ManufacturerKey = model.ManufacturerKey,
                    StartYear = model.StartYear,
                    DepreciationFactor = model.DepreciationFactor,
                    AssetLife = model.AssetLife,
                };

                viewModel.AssetCategoryName = model.CategoryKey != null ? model.AssetCategory.CategoryName : "n/a";
                viewModel.AssetSubcategoryName = model.SubcategoryKey != null ? model.AssetSubcategory.SubcategoryName : "n/a";
                viewModel.ManufacturerName = model.ManufacturerKey != null ? model.Manufacturer.ManufacturerName : "n/a";
                viewModel.UnitName = model.UnitKey != null ? model.Unit.UnitName : "n/a";

                return View(viewModel);
            }

        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.Asset.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            try
            {
                model.IsDelete = true;
                db.SaveChanges();
                RenderSuccessMessage("Asset is successfully deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RenderDangerMessage("Asset could not be deleted due to an error.");
                return RedirectToAction("Index");
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