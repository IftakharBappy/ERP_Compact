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
    public class MgtItemController : BaseController
    {
        // GET: MgtItem
        public ActionResult Index()
        {
            var list = db.Item.Where(a => a.IsDelete == false).Select(model =>
            new ItemViewModel()
            {
                ItemKey = model.ItemKey,
                ItemID = model.ItemID,
                ItemName = model.ItemName,
                ModelNo = model.ModelNo,
                ItemCategoryName = model.CategoryKey != null ? db.ItemCategory.Where(c => c.CategoryKey == model.CategoryKey).Select(c => c.CategoryName).FirstOrDefault() : "n/a"
            }
            ).ToList();
            return View(list);

        }


        public ActionResult Create()
        {
            ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName");
            ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName");
            ViewBag.UnitKey = new SelectList(db.Unit.Where(x => x.IsDelete == false), "UnitKey", "UnitID");
            ViewBag.TypeKey = new SelectList(db.ItemType.Where(x => x.IsDelete == false), "TypeKey", "TypeID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Logo")] ItemViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new Item();
                    model.IsDelete = false;
                    model.ItemKey = Guid.NewGuid();

                    model.ItemName = viewModel.ItemName;
                    model.ItemID = viewModel.ItemID;
                    model.Description = string.IsNullOrEmpty(viewModel.Description) ? "n/a" : viewModel.Description;
                    model.ProductID = string.IsNullOrEmpty(viewModel.ProductID) ? viewModel.ItemID : viewModel.ProductID;
                    model.UnitKey = viewModel.UnitKey;
                    model.Unitsize = viewModel.Unitsize == null ? 1 : viewModel.Unitsize;
                    model.CategoryKey = viewModel.CategoryKey;
                    model.SubcategoryKey = viewModel.SubcategoryKey;
                    model.TypeKey = viewModel.TypeKey;
                    model.ModelNo = string.IsNullOrEmpty(viewModel.ModelNo) ? "n/a" : viewModel.ModelNo;
                    model.ItemColor = string.IsNullOrEmpty(viewModel.ItemColor) ? "n/a" : viewModel.ItemColor;
                    model.ReorderLevel = viewModel.ReorderLevel == null ? 1 : viewModel.ReorderLevel;

                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.logo = imgBinaryData;
                    //model.Logotype = Logo.ContentType; #todo

                    db.Item.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Item is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Item could not be created due to an error.");
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName");//# todo manage properly
                ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName");// to send and empty list
                ViewBag.UnitKey = new SelectList(db.Unit.Where(x => x.IsDelete == false), "UnitKey", "UnitID",viewModel.UnitKey);
                ViewBag.TypeKey = new SelectList(db.ItemType.Where(x => x.IsDelete == false), "TypeKey", "TypeID",viewModel.TypeKey);
                return View(viewModel);
            }

        }


        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.Item.Where(x => x.ItemKey == id).Select(model => new ItemViewModel()
            {
                ItemKey = model.ItemKey,
                ItemName = model.ItemName,
                ItemID = model.ItemID,
                Description = model.Description,
                ProductID = model.ProductID,
                UnitKey = model.UnitKey,
                Unitsize = model.Unitsize,
                CategoryKey = model.CategoryKey,
                SubcategoryKey = model.SubcategoryKey,
                TypeKey = model.TypeKey,
                ModelNo = model.ModelNo,
                ItemColor = model.ItemColor,
                ReorderLevel = model.ReorderLevel,
                Logo = model.logo,
                //Logotype = model.Logotype,
            }).FirstOrDefault();

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName", viewModel.CategoryKey);
            ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName", viewModel.SubcategoryKey);// to send and empty list
            ViewBag.UnitKey = new SelectList(db.Unit.Where(x => x.IsDelete == false), "UnitKey", "UnitID", viewModel.UnitKey);
            ViewBag.TypeKey = new SelectList(db.ItemType.Where(x => x.IsDelete == false), "TypeKey", "TypeID", viewModel.TypeKey);

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Logo")] ItemViewModel viewModel, HttpPostedFileBase Logo)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.Item.Where(x => x.ItemKey == viewModel.ItemKey).FirstOrDefault();

                    model.ItemName = viewModel.ItemName;
                    model.ItemID = viewModel.ItemID;
                    model.Description = string.IsNullOrEmpty(viewModel.Description) ? "n/a" : viewModel.Description;
                    model.ProductID = string.IsNullOrEmpty(viewModel.ProductID) ? viewModel.ItemID : viewModel.ProductID;
                    model.UnitKey = viewModel.UnitKey;
                    model.Unitsize = viewModel.Unitsize == null ? 1 : viewModel.Unitsize;
                    model.CategoryKey = viewModel.CategoryKey;
                    model.SubcategoryKey = viewModel.SubcategoryKey;
                    model.TypeKey = viewModel.TypeKey;
                    model.ModelNo = string.IsNullOrEmpty(viewModel.ModelNo) ? "n/a" : viewModel.ModelNo;
                    model.ItemColor = string.IsNullOrEmpty(viewModel.ItemColor) ? "n/a" : viewModel.ItemColor;
                    model.ReorderLevel = viewModel.ReorderLevel == null ? 1 : viewModel.ReorderLevel;

                    if (viewModel.KeepOldLogo == false)
                    {
                        byte[] imgBinaryData = new byte[Logo.ContentLength];
                        int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                        model.logo = imgBinaryData;
                        //model.Logotype = Logo.ContentType; # todo
                    }

                    db.SaveChanges();

                    RenderSuccessMessage("Item is successfully updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Item could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.UnitKey });
                }
            }
            else
            {

                ViewBag.CategoryKeyKey = new SelectList(db.AssetCategory, "CategoryKey", "CategoryName");//# todo manage properly
                ViewBag.SubcategoryKey = new SelectList(db.AssetSubcategory, "SubcategoryKey", "SubcategoryName");// to send and empty list
                ViewBag.UnitKey = new SelectList(db.Unit, "UnitKey", "UnitID", viewModel.UnitKey);
                ViewBag.TypeKey = new SelectList(db.ItemType, "TypeKey", "TypeID", viewModel.TypeKey);

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
            var model = db.Item.Where(x => x.ItemKey == id).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new ItemViewModel()
                {
                    ItemKey = model.ItemKey,
                    ItemName = model.ItemName,
                    ItemID = model.ItemID,
                    Description = model.Description,
                    ProductID = model.ProductID,
                    UnitKey = model.UnitKey,
                    Unitsize = model.Unitsize,
                    CategoryKey = model.CategoryKey,
                    SubcategoryKey = model.SubcategoryKey,
                    TypeKey = model.TypeKey,
                    ModelNo = model.ModelNo,
                    ItemColor = model.ItemColor,
                    ReorderLevel = model.ReorderLevel,
                    Logo = model.logo,
                    //Logotype = model.Logotype,
                };

                viewModel.ItemCategoryName = model.CategoryKey != null ? model.ItemCategory.CategoryName : "n/a";
                viewModel.ItemSubcategoryName = model.SubcategoryKey != null ? model.ItemSubcategory.SubcategoryName : "n/a";
                viewModel.ItemTypeName = model.TypeKey != null ? model.ItemType.TypeName : "n/a";
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

            var model = db.Item.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            try
            {
                model.IsDelete = true;
                db.SaveChanges();
                RenderSuccessMessage("Item is successfully deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RenderDangerMessage("Item could not be deleted due to an error.");
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