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
    public class MgtSupplierController : BaseController
    {
        public ActionResult Index()
        {
            var list = db.Supplier.Where(x => x.IsDelete == false).Select(model =>
               new SupplierViewModel()
               {
                   SupplierID = model.SupplierID,
                   SupplierName = model.SupplierName,
                   SupplierAddress = model.SupplierAddress,
                   SupplierEmail = model.SupplierEmail
               }).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");
            ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// to send and empty list
            ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// to send and empty list
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Logo")] SupplierViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new Supplier();
                    model.IsDelete = false;
                    model.SupplierID = Guid.NewGuid();
                    model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;

                    model.SupplierName = viewModel.SupplierName;
                    model.SupplierAddress = viewModel.SupplierAddress;
                    model.SupplierPhone = string.IsNullOrEmpty(viewModel.SupplierPhone) ? "n/a" : viewModel.SupplierPhone;
                    model.SupplierMobile = string.IsNullOrEmpty(viewModel.SupplierMobile) ? "n/a" : viewModel.SupplierMobile;
                    model.SupplierEmail = string.IsNullOrEmpty(viewModel.SupplierEmail) ? "n/a" : viewModel.SupplierEmail;
                    model.SupplierWebsite = string.IsNullOrEmpty(viewModel.SupplierWebsite) ? "n/a" : viewModel.SupplierWebsite;
                    model.SupplierFax = string.IsNullOrEmpty(viewModel.SupplierFax) ? "n/a" : viewModel.SupplierFax;
                    model.ContactPersonName = string.IsNullOrEmpty(viewModel.ContactPersonName) ? "n/a" : viewModel.ContactPersonName;
                    model.ContactPersonNo = string.IsNullOrEmpty(viewModel.ContactPersonNo) ? "n/a" : viewModel.ContactPersonNo;


                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.Logo = imgBinaryData;
                    model.LogoType = Logo.ContentType;

                    model.DiscountPerc = viewModel.DiscountPerc != null ? viewModel.DiscountPerc : 0;
                    model.DiscountAmt = viewModel.DiscountAmt != null ? viewModel.DiscountAmt : 0;
                    model.Incentive = viewModel.Incentive != null ? viewModel.Incentive : 0;
                    model.UpazillaKey = viewModel.UpazillaKey;
                    db.Supplier.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Supplier is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Supplier could not be created due to an error.");
                }

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// #todo manage later
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// #todo manage later
                return View(viewModel);
            }

        }


        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.Supplier.Where(x => x.SupplierID == id).Select(model => new SupplierViewModel()
            {
                SupplierID = model.SupplierID,
                SupplierName = model.SupplierName,
                SupplierAddress = model.SupplierAddress,
                SupplierPhone = model.SupplierPhone,
                SupplierMobile = model.SupplierMobile,
                SupplierEmail = model.SupplierEmail,
                SupplierWebsite = model.SupplierWebsite,
                SupplierFax = model.SupplierFax,
                ContactPersonName = model.ContactPersonName,
                ContactPersonNo = model.ContactPersonNo,
                DiscountPerc = model.DiscountPerc,
                DiscountAmt = model.DiscountAmt,
                Incentive = model.Incentive,
                UpazillaKey = model.UpazillaKey,
                Logo = model.Logo,
                LogoType = model.LogoType
            }).FirstOrDefault();

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            if (viewModel.UpazillaKey != null)
            {
                var uapzialla = db.Upazilla.Where(x => x.UpazillaKey == viewModel.UpazillaKey).Include(x => x.District).Include(x => x.District.Division).FirstOrDefault();
                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID", uapzialla.District.Division.DivisionKey);
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.IsDelete == false && x.DivisionKey == uapzialla.District.Division.DivisionKey), "DistrictKey", "DistrictID", uapzialla.District.DistrictKey);
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.IsDelete == false && x.DistrictKey == uapzialla.District.DistrictKey), "UpazillaKey", "UpazillaID", viewModel.UpazillaKey);
            }
            else
            {
                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// to send and empty list
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// to send and empty list
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Logo")] SupplierViewModel viewModel, HttpPostedFileBase Logo)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.Supplier.Where(x => x.SupplierID == viewModel.SupplierID).FirstOrDefault();


                    model.SupplierName = viewModel.SupplierName;
                    model.SupplierAddress = viewModel.SupplierAddress;
                    model.SupplierPhone = string.IsNullOrEmpty(viewModel.SupplierPhone) ? "n/a" : viewModel.SupplierPhone;
                    model.SupplierMobile = string.IsNullOrEmpty(viewModel.SupplierMobile) ? "n/a" : viewModel.SupplierMobile;
                    model.SupplierEmail = string.IsNullOrEmpty(viewModel.SupplierEmail) ? "n/a" : viewModel.SupplierEmail;
                    model.SupplierWebsite = string.IsNullOrEmpty(viewModel.SupplierWebsite) ? "n/a" : viewModel.SupplierWebsite;
                    model.SupplierFax = string.IsNullOrEmpty(viewModel.SupplierFax) ? "n/a" : viewModel.SupplierFax;
                    model.ContactPersonName = string.IsNullOrEmpty(viewModel.ContactPersonName) ? "n/a" : viewModel.ContactPersonName;
                    model.ContactPersonNo = string.IsNullOrEmpty(viewModel.ContactPersonNo) ? "n/a" : viewModel.ContactPersonNo;

                    if (viewModel.KeepOldLogo == false)
                    {
                        byte[] imgBinaryData = new byte[Logo.ContentLength];
                        int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                        model.Logo = imgBinaryData;
                        model.LogoType = Logo.ContentType;
                    }
                    model.DiscountPerc = viewModel.DiscountPerc != null ? viewModel.DiscountPerc : 0;
                    model.DiscountAmt = viewModel.DiscountAmt != null ? viewModel.DiscountAmt : 0;
                    model.Incentive = viewModel.Incentive != null ? viewModel.Incentive : 0;
                    model.UpazillaKey = viewModel.UpazillaKey;
                    db.Supplier.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Supplier is successfully Updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Supplier could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.SupplierID });
                }
            }
            else
            {
                viewModel.Logo = db.Supplier.Where(x => x.SupplierID == viewModel.SupplierID).Select(x => x.Logo).FirstOrDefault();
                if (viewModel.UpazillaKey != null)
                {
                    var uapzialla = db.Upazilla.Where(x => x.UpazillaKey == viewModel.UpazillaKey).Include(x => x.District).Include(x => x.District.Division).FirstOrDefault();
                    ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID", uapzialla.District.Division.DivisionKey);
                    ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.IsDelete == false && x.DivisionKey == uapzialla.District.Division.DivisionKey), "DistrictKey", "DistrictID", uapzialla.District.DistrictKey);
                    ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.IsDelete == false && x.DistrictKey == uapzialla.District.DistrictKey), "UpazillaKey", "UpazillaID", viewModel.UpazillaKey);
                }
                else
                {
                    ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");
                    ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// to send and empty list
                    ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// to send and empty list
                }

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
            var model = db.Supplier.Where(x => x.SupplierID == id).Include(x => x.Upazilla).Include(x => x.Upazilla.District).Include(x => x.Upazilla.District.Division).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new SupplierViewModel()
                {
                    SupplierID = model.SupplierID,
                    SupplierName = model.SupplierName,
                    SupplierAddress = model.SupplierAddress,
                    SupplierPhone = model.SupplierPhone,
                    SupplierMobile = model.SupplierMobile,
                    SupplierEmail = model.SupplierEmail,
                    SupplierWebsite = model.SupplierWebsite,
                    SupplierFax = model.SupplierFax,
                    ContactPersonName = model.ContactPersonName,
                    ContactPersonNo = model.ContactPersonNo,
                    DiscountPerc = model.DiscountPerc,
                    DiscountAmt = model.DiscountAmt,
                    Incentive = model.Incentive,
                    UpazillaKey = model.UpazillaKey,
                    Logo = model.Logo,
                    LogoType = model.LogoType
                };

                viewModel.DivisionName = model.Upazilla.District.Division != null ? model.Upazilla.District.Division.DivisionName : "n/a";
                viewModel.DistrictName = model.Upazilla.District != null ? model.Upazilla.District.DistrictName : "n/a";
                viewModel.UpazillaName = model.Upazilla != null ? model.Upazilla.UpazillaName : "n/a";

                return View(viewModel);
            }

        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.Supplier.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            try
            {
                model.IsDelete = true;
                db.SaveChanges();
                RenderSuccessMessage("Supplier is successfully deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RenderDangerMessage("Supplier could not be deleted due to an error.");
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