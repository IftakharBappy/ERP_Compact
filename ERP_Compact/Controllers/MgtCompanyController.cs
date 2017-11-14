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
    public class MgtCompanyController : BaseController
    {

        public ActionResult Index()
        {
            var companyViewModelList = db.Company.Where(x=>x.IsDelete==false).Select(model => new CompanyViewModel()
            {
                CompanyKey = model.CompanyKey,
                CompanyName = model.CompanyName,
                CompanyPhone = model.CompanyPhone,
                CompanyAddress = model.CompanyAddress,
                CompanyEmail = model.CompanyEmail
            }).ToList();
            
            return View(companyViewModelList);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Company.Where(x=>x.CompanyKey == id).Include(x => x.Division).Include(x => x.District).Include(x => x.Upazilla).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CompanyViewModel()
                {
                    CompanyKey = model.CompanyKey,
                    CompanyName = model.CompanyName,
                    CompanyID = model.CompanyID,
                    CompanyAddress = model.CompanyAddress,
                    CompanyPhone = model.CompanyPhone,
                    CompanyMobile = model.CompanyMobile,
                    CompanyEmail = model.CompanyEmail,
                    CompanyWebsite = model.CompanyWebsite,
                    CompanyFax = model.CompanyFax,
                    ContactPersonName = model.ContactPersonName,
                    ContactPersonNo = model.ContactPersonNo,
                    Logo = model.Logo,
                    LogoType = model.LogoType,
                };

                viewModel.DivisionName = model.Division != null ? model.Division.DivisionName : "n/a";
                viewModel.DistrictName= model.District != null ? model.District.DistrictName : "n/a";
                viewModel.UpazillaName= model.Upazilla != null ? model.Upazilla.UpazillaName : "n/a";

                return View(viewModel);
            }
            
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
        public ActionResult Create([Bind(Exclude = "Logo")] CompanyViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Company model = new Company();
                    model.IsDelete = false;
                    model.CompanyKey = Guid.NewGuid();

                    model.CompanyName = viewModel.CompanyName;
                    model.CompanyID = string.IsNullOrEmpty(viewModel.CompanyID) ? viewModel.CompanyName : viewModel.CompanyID;
                    model.CompanyAddress = viewModel.CompanyAddress;
                    model.CompanyPhone = string.IsNullOrEmpty(viewModel.CompanyPhone) ? "n/a" : viewModel.CompanyPhone;
                    model.CompanyMobile = string.IsNullOrEmpty(viewModel.CompanyMobile) ? "n/a" : viewModel.CompanyMobile;
                    model.CompanyEmail = string.IsNullOrEmpty(viewModel.CompanyEmail) ? "n/a" : viewModel.CompanyEmail;
                    model.CompanyWebsite = string.IsNullOrEmpty(viewModel.CompanyWebsite) ? "n/a" : viewModel.CompanyWebsite;
                    model.CompanyFax = string.IsNullOrEmpty(viewModel.CompanyFax) ? "n/a" : viewModel.CompanyFax;
                    model.ContactPersonName = string.IsNullOrEmpty(viewModel.ContactPersonName) ? "n/a" : viewModel.ContactPersonName;
                    model.ContactPersonNo = string.IsNullOrEmpty(viewModel.ContactPersonNo) ? "n/a" : viewModel.ContactPersonNo;
                    model.DivisionKey = viewModel.DivisionKey;
                    model.DistrictKey = viewModel.DistrictKey;
                    model.UpazillaKey = viewModel.UpazillaKey;
                    
                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.Logo = imgBinaryData;
                    model.LogoType = Logo.ContentType;
                    db.Company.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Company is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Company could not be created due to an error.");
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

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.Company.Where(x => x.CompanyKey == id).Select(model => new CompanyViewModel()
            {
                CompanyKey = model.CompanyKey,
                CompanyName = model.CompanyName,
                CompanyID = model.CompanyID,
                CompanyAddress = model.CompanyAddress,
                CompanyPhone = model.CompanyPhone,
                CompanyMobile = model.CompanyMobile,
                CompanyEmail = model.CompanyEmail,
                CompanyWebsite = model.CompanyWebsite,
                CompanyFax = model.CompanyFax,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Logo")] CompanyViewModel viewModel, HttpPostedFileBase Logo)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    Company model = db.Company.Where(x => x.CompanyKey == viewModel.CompanyKey).FirstOrDefault();

                    model.CompanyName = viewModel.CompanyName;
                    model.CompanyID = string.IsNullOrEmpty(viewModel.CompanyID) ? viewModel.CompanyName : viewModel.CompanyID;
                    model.CompanyAddress = viewModel.CompanyAddress;
                    model.CompanyPhone = string.IsNullOrEmpty(viewModel.CompanyPhone) ? "n/a" : viewModel.CompanyPhone;
                    model.CompanyMobile = string.IsNullOrEmpty(viewModel.CompanyMobile) ? "n/a" : viewModel.CompanyMobile;
                    model.CompanyEmail = string.IsNullOrEmpty(viewModel.CompanyEmail) ? "n/a" : viewModel.CompanyEmail;
                    model.CompanyWebsite = string.IsNullOrEmpty(viewModel.CompanyWebsite) ? "n/a" : viewModel.CompanyWebsite;
                    model.CompanyFax = string.IsNullOrEmpty(viewModel.CompanyFax) ? "n/a" : viewModel.CompanyFax;
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

                    RenderSuccessMessage("Company is successfully updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Company could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.CompanyKey });
                }
            }
            else
            {
                viewModel.Logo = db.Company.Where(x => x.CompanyKey == viewModel.CompanyKey).Select(x => x.Logo).FirstOrDefault();
                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID", viewModel.DivisionKey);
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.IsDelete == false && x.DivisionKey == viewModel.DivisionKey), "DistrictKey", "DistrictID", viewModel.DistrictKey);
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.IsDelete == false && x.DistrictKey == viewModel.DistrictKey), "UpazillaKey", "UpazillaID", viewModel.UpazillaKey);

                RenderInfoMessage("Please, provide all required data.");
                return View(viewModel);
            }
            
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            try
            {
                company.IsDelete = true;
                db.SaveChanges();
                RenderSuccessMessage("Company is successfully deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RenderDangerMessage("Company could not be deleted due to an error.");
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
