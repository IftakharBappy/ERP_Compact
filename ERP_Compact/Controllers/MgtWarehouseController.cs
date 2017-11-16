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
    public class MgtWarehouseController : BaseController
    {
        public ActionResult Index()
        {
            var warehouseList = db.Warehouse.Where(x=>x.IsDelete==false).Select(model=> new WarehouseViewModel() {
                WarehouseKey=model.WarehouseKey,
                WahouseName=model.WahouseName,
                WahousePhone=model.WahousePhone,
                WahouseAddress=model.WahouseAddress,
                WahouseEmail=model.WahouseEmail

            }).ToList();
            return View(warehouseList);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Warehouse.Where(x => x.WarehouseKey == id).Include(x => x.Division).Include(x => x.District).Include(x => x.Upazilla).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new WarehouseViewModel()
                {
                    WarehouseKey = model.WarehouseKey,
                    WahouseID = model.WahouseID,
                    WahouseName = model.WahouseName,
                    WahouseAddress = model.WahouseAddress,
                    WahousePhone = model.WahousePhone,
                    WahouseMobile = model.WahouseMobile,
                    WahouseEmail = model.WahouseEmail,
                    WahouseWebsite = model.WahouseWebsite,
                    WahouseFax = model.WahouseFax,
                    ContactPersonName = model.ContactPersonName,
                    ContactPersonNo = model.ContactPersonNo,
                    Logo = model.Logo,
                    LogoType = model.LogoType,
                };

                viewModel.DivisionName = model.Division != null ? model.Division.DivisionName : "n/a";
                viewModel.DistrictName = model.District != null ? model.District.DistrictName : "n/a";
                viewModel.UpazillaName = model.Upazilla != null ? model.Upazilla.UpazillaName : "n/a";

                return View(viewModel);
            }

        }

        // GET: MgtWarehouse/Create
        public ActionResult Create()
        {
            ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");
            ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// to send and empty list
            ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// to send and empty list
            return View();
        }

        // POST: MgtWarehouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Logo")] WarehouseViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Warehouse model = new Warehouse();
                    model.IsDelete = false;
                    model.WarehouseKey = Guid.NewGuid();

                    model.WahouseName = viewModel.WahouseName;
                    model.WahouseID = string.IsNullOrEmpty(viewModel.WahouseID) ? viewModel.WahouseName : viewModel.WahouseID;
                    model.WahouseAddress = viewModel.WahouseAddress;
                    model.WahousePhone = string.IsNullOrEmpty(viewModel.WahousePhone) ? "n/a" : viewModel.WahousePhone;
                    model.WahouseMobile = string.IsNullOrEmpty(viewModel.WahouseMobile) ? "n/a" : viewModel.WahouseMobile;
                    model.WahouseEmail = string.IsNullOrEmpty(viewModel.WahouseEmail) ? "n/a" : viewModel.WahouseEmail;
                    model.WahouseWebsite = string.IsNullOrEmpty(viewModel.WahouseWebsite) ? "n/a" : viewModel.WahouseWebsite;
                    model.WahouseFax = string.IsNullOrEmpty(viewModel.WahouseFax) ? "n/a" : viewModel.WahouseFax;
                    model.ContactPersonName = string.IsNullOrEmpty(viewModel.ContactPersonName) ? "n/a" : viewModel.ContactPersonName;
                    model.ContactPersonNo = string.IsNullOrEmpty(viewModel.ContactPersonNo) ? "n/a" : viewModel.ContactPersonNo;
                    model.DivisionKey = viewModel.DivisionKey;
                    model.DistrictKey = viewModel.DistrictKey;
                    model.UpazillaKey = viewModel.UpazillaKey;

                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.Logo = imgBinaryData;
                    model.LogoType = Logo.ContentType;
                    db.Warehouse.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Warehouse is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Warehouse could not be created due to an error.");
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID", viewModel.DivisionKey);
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.IsDelete == false && x.DivisionKey == viewModel.DivisionKey), "DistrictKey", "DistrictID", viewModel.DistrictKey);
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.IsDelete == false && x.DistrictKey == viewModel.DistrictKey), "UpazillaKey", "UpazillaID", viewModel.UpazillaKey);
                return View(viewModel);
            }

        }

        // GET: MgtWarehouse/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.Warehouse.Where(x => x.WarehouseKey == id).Select(model => new WarehouseViewModel()
            {
                WarehouseKey = model.WarehouseKey,
                WahouseName = model.WahouseName,
                WahouseID = model.WahouseID,
                WahouseAddress = model.WahouseAddress,
                WahousePhone = model.WahousePhone,
                WahouseMobile = model.WahouseMobile,
                WahouseEmail= model.WahouseEmail,
                WahouseWebsite = model.WahouseWebsite,
                WahouseFax= model.WahouseFax,
                ContactPersonName = model.ContactPersonName,
                ContactPersonNo = model.ContactPersonNo,
                DivisionKey = model.DivisionKey,
                DistrictKey = model.DistrictKey,
                UpazillaKey = model.UpazillaKey,
                Logo = model.Logo,
                LogoType = model.LogoType
            }).FirstOrDefault();

            if (viewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID", viewModel.DivisionKey);
            ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.IsDelete == false && x.DivisionKey == viewModel.DivisionKey), "DistrictKey", "DistrictID", viewModel.DistrictKey);
            ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.IsDelete == false && x.DistrictKey == viewModel.DistrictKey), "UpazillaKey", "UpazillaID", viewModel.UpazillaKey);
            return View(viewModel);
        }

        // POST: MgtWarehouse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Logo")] WarehouseViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Warehouse model = db.Warehouse.Where(x => x.WarehouseKey== viewModel.WarehouseKey).FirstOrDefault();

                    model.WahouseName = viewModel.WahouseName;
                    model.WahouseID = string.IsNullOrEmpty(viewModel.WahouseID) ? viewModel.WahouseName : viewModel.WahouseID;
                    model.WahouseAddress = viewModel.WahouseAddress;
                    model.WahousePhone = string.IsNullOrEmpty(viewModel.WahousePhone) ? "n/a" : viewModel.WahousePhone;
                    model.WahouseMobile= string.IsNullOrEmpty(viewModel.WahouseMobile) ? "n/a" : viewModel.WahouseMobile;
                    model.WahouseEmail= string.IsNullOrEmpty(viewModel.WahouseEmail) ? "n/a" : viewModel.WahouseEmail;
                    model.WahouseWebsite= string.IsNullOrEmpty(viewModel.WahouseWebsite) ? "n/a" : viewModel.WahouseWebsite;
                    model.WahouseFax= string.IsNullOrEmpty(viewModel.WahouseFax) ? "n/a" : viewModel.WahouseFax;
                    model.ContactPersonName = string.IsNullOrEmpty(viewModel.ContactPersonName) ? "n/a" : viewModel.ContactPersonName;
                    model.ContactPersonNo = string.IsNullOrEmpty(viewModel.ContactPersonNo) ? "n/a" : viewModel.ContactPersonNo;
                    model.DivisionKey = viewModel.DivisionKey;
                    model.DistrictKey = viewModel.DistrictKey;
                    model.UpazillaKey = viewModel.UpazillaKey;

                    if (viewModel.KeepOldLogo == false)
                    {
                        byte[] imgBinaryData = new byte[Logo.ContentLength];
                        int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                        model.Logo = imgBinaryData;
                        model.LogoType = Logo.ContentType;
                    }
                    db.SaveChanges();

                    RenderSuccessMessage("Wahouse is successfully updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Wahouse could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.WarehouseKey });
                }
            }
            else
            {
                viewModel.Logo = db.Company.Where(x => x.CompanyKey == viewModel.WarehouseKey).Select(x => x.Logo).FirstOrDefault();
                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID", viewModel.DivisionKey);
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.IsDelete == false && x.DivisionKey == viewModel.DivisionKey), "DistrictKey", "DistrictID", viewModel.DistrictKey);
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.IsDelete == false && x.DistrictKey == viewModel.DistrictKey), "UpazillaKey", "UpazillaID", viewModel.UpazillaKey);

                RenderInfoMessage("Please, provide all required data.");
                return View(viewModel);
            }

        }

        // GET: MgtWarehouse/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.Warehouse.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            try
            {
                model.IsDelete = true;
                db.SaveChanges();
                RenderSuccessMessage("Warehouse is successfully deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RenderDangerMessage("Warehouse could not be deleted due to an error.");
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
