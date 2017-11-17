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
    public class MgtCustomerController : BaseController
    {
        public ActionResult Index()
        {
            var list = db.Customer.Where(x => x.IsDelete == false).Select(model =>
               new CustomerViewModel() {
                   CustomerKey = model.CustomerKey,
                   CustomerName = model.CustomerName,
                   CPhone = model.CPhone,
                   CustomeAddress = model.CustomeAddress,
                   CEmail = model.CEmail
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
        public ActionResult Create([Bind(Exclude = "Logo")] CustomerViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer model = new Customer();
                    model.IsDelete = false;
                    model.CustomerKey = Guid.NewGuid();
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;

                    model.CustomerName = viewModel.CustomerName;
                    model.CustomeID = string.IsNullOrEmpty(viewModel.CustomeID) ? viewModel.CustomerName : viewModel.CustomeID;
                    model.CustomeAddress = viewModel.CustomeAddress;
                    model.CPhone = string.IsNullOrEmpty(viewModel.CPhone) ? "n/a" : viewModel.CPhone;
                    model.CMobile = string.IsNullOrEmpty(viewModel.CMobile) ? "n/a" : viewModel.CMobile;
                    model.CEmail = string.IsNullOrEmpty(viewModel.CEmail) ? "n/a" : viewModel.CEmail;
                    model.CWebsite = string.IsNullOrEmpty(viewModel.CWebsite) ? "n/a" : viewModel.CWebsite;
                    model.CFax = string.IsNullOrEmpty(viewModel.CFax) ? "n/a" : viewModel.CFax;
                    model.ContactPersonName = string.IsNullOrEmpty(viewModel.ContactPersonName) ? "n/a" : viewModel.ContactPersonName;
                    model.ContactPersonNo = string.IsNullOrEmpty(viewModel.ContactPersonNo) ? "n/a" : viewModel.ContactPersonNo;
                    

                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.Logo = imgBinaryData;
                    model.LogoType = Logo.ContentType;

                    model.DiscountPerc = viewModel.DiscountPerc != null? viewModel.DiscountPerc : 0;
                    model.DiscountAmt = viewModel.DiscountAmt != null ? viewModel.DiscountAmt : 0;
                    model.Incentive = viewModel.Incentive != null ? viewModel.Incentive : 0;
                    model.UpazillaKey = viewModel.UpazillaKey;
                    db.Customer.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Customer is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Customer could not be created due to an error.");
                }

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// to send and empty list
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// to send and empty list
                return View(viewModel);
            }

        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.Customer.Where(x => x.CustomerKey == id).Select(model => new CustomerViewModel()
            {
                CustomerKey = model.CustomerKey,
                CustomerName = model.CustomerName,
                CustomeID = model.CustomeID,
                CustomeAddress = model.CustomeAddress,
                CPhone = model.CPhone,
                CMobile = model.CMobile,
                CEmail= model.CEmail,
                CWebsite= model.CWebsite,
                CFax= model.CFax,
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
        public ActionResult Edit([Bind(Exclude = "Logo")] CustomerViewModel viewModel, HttpPostedFileBase Logo)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer model = db.Customer.Where(x => x.CustomerKey== viewModel.CustomerKey).FirstOrDefault();

                    model.CustomerName = viewModel.CustomerName;
                    model.CustomeID = string.IsNullOrEmpty(viewModel.CustomeID) ? viewModel.CustomerName : viewModel.CustomeID;
                    model.CustomeAddress = viewModel.CustomeAddress;
                    model.CPhone = string.IsNullOrEmpty(viewModel.CPhone) ? "n/a" : viewModel.CPhone;
                    model.CMobile = string.IsNullOrEmpty(viewModel.CMobile) ? "n/a" : viewModel.CMobile;
                    model.CEmail = string.IsNullOrEmpty(viewModel.CEmail) ? "n/a" : viewModel.CEmail;
                    model.CWebsite = string.IsNullOrEmpty(viewModel.CWebsite) ? "n/a" : viewModel.CWebsite;
                    model.CFax = string.IsNullOrEmpty(viewModel.CFax) ? "n/a" : viewModel.CFax;
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
                    db.SaveChanges();

                    RenderSuccessMessage("Company is successfully updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Company could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.CustomerKey });
                }
            }
            else
            {
                viewModel.Logo = db.Customer.Where(x => x.CustomerKey == viewModel.CustomerKey).Select(x => x.Logo).FirstOrDefault();
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
            var model = db.Customer.Where(x => x.CustomerKey == id).Include(x => x.Upazilla).Include(x => x.Upazilla.District).Include(x => x.Upazilla.District.Division).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerViewModel()
                {
                    CustomerKey = model.CustomerKey,
                    CustomerName = model.CustomerName,
                    CustomeID = model.CustomeID,
                    CustomeAddress = model.CustomeAddress,
                    CPhone = model.CPhone,
                    CMobile = model.CMobile,
                    CEmail = model.CEmail,
                    CWebsite = model.CWebsite,
                    CFax = model.CFax,
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

            var model = db.Customer.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            try
            {
                model.IsDelete = true;
                db.SaveChanges();
                RenderSuccessMessage("Customer is successfully deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RenderDangerMessage("Customer could not be deleted due to an error.");
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