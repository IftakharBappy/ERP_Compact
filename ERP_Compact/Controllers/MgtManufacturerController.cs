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
    public class MgtManufacturerController : BaseController
    {
        // GET: MgtManufacturer
        public ActionResult Index()
        {
            var list = db.Manufacturer.Where(x => x.IsDelete == false).Select(model =>
               new ManufacturerViewModel()
               {
                   ManufacturerKey = model.ManufacturerKey,
                   ManufacturerName = model.ManufacturerName,
                   ManufacturerAddress = model.ManufacturerAddress,
                   CountryOfOrigin = model.CountryOfOrigin
               }).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Logo")] ManufacturerViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Manufacturer model = new Manufacturer();
                    model.IsDelete = false;
                    model.ManufacturerKey = Guid.NewGuid();

                    model.ManufacturerName = viewModel.ManufacturerName;
                    model.ManufacturerID = string.IsNullOrEmpty(viewModel.ManufacturerID) ? viewModel.ManufacturerName : viewModel.ManufacturerID;
                    model.ManufacturerAddress = viewModel.ManufacturerAddress;
                    model.CountryOfOrigin = string.IsNullOrEmpty(viewModel.CountryOfOrigin) ? "n/a" : viewModel.CountryOfOrigin;
                    model.CPhone = string.IsNullOrEmpty(viewModel.CPhone) ? "n/a" : viewModel.CPhone;
                    model.CEmail = string.IsNullOrEmpty(viewModel.CEmail) ? "n/a" : viewModel.CEmail;
                    model.CWebsite = string.IsNullOrEmpty(viewModel.CWebsite) ? "n/a" : viewModel.CWebsite;
                    model.CFax = string.IsNullOrEmpty(viewModel.CFax) ? "n/a" : viewModel.CFax;


                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.Logo = imgBinaryData;
                    model.LogoType = Logo.ContentType;

                    db.Manufacturer.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("Manufacturer is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Manufacturer could not be created due to an error.");
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }

        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.Manufacturer.Where(x => x.ManufacturerKey == id).Select(model => new ManufacturerViewModel()
            {
                ManufacturerKey = model.ManufacturerKey,
                ManufacturerName = model.ManufacturerName,
                ManufacturerID = model.ManufacturerID,
                ManufacturerAddress = model.ManufacturerAddress,
                CountryOfOrigin = model.CountryOfOrigin,
                CPhone = model.CPhone,
                CEmail = model.CEmail,
                CWebsite = model.CWebsite,
                CFax = model.CFax,
                Logo = model.Logo,
                LogoType = model.LogoType
            }).FirstOrDefault();

            if (viewModel == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Logo")] ManufacturerViewModel viewModel, HttpPostedFileBase Logo)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    Manufacturer model = db.Manufacturer.Where(x => x.ManufacturerKey == viewModel.ManufacturerKey).FirstOrDefault();

                    model.ManufacturerName = viewModel.ManufacturerName;
                    model.ManufacturerID = string.IsNullOrEmpty(viewModel.ManufacturerID) ? viewModel.ManufacturerName : viewModel.ManufacturerID;
                    model.ManufacturerAddress = viewModel.ManufacturerAddress;
                    model.CountryOfOrigin = string.IsNullOrEmpty(viewModel.CountryOfOrigin) ? "n/a" : viewModel.CountryOfOrigin;
                    model.CPhone = string.IsNullOrEmpty(viewModel.CPhone) ? "n/a" : viewModel.CPhone;
                    model.CEmail = string.IsNullOrEmpty(viewModel.CEmail) ? "n/a" : viewModel.CEmail;
                    model.CWebsite = string.IsNullOrEmpty(viewModel.CWebsite) ? "n/a" : viewModel.CWebsite;
                    model.CFax = string.IsNullOrEmpty(viewModel.CFax) ? "n/a" : viewModel.CFax;
                    if (viewModel.KeepOldLogo == false)
                    {
                        byte[] imgBinaryData = new byte[Logo.ContentLength];
                        int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                        model.Logo = imgBinaryData;
                        model.LogoType = Logo.ContentType;
                    }

                    db.SaveChanges();

                    RenderSuccessMessage("Manufacturer is successfully updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("Manufacturer could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.ManufacturerKey });
                }
            }
            else
            {
                viewModel.Logo = db.Manufacturer.Where(x => x.ManufacturerKey == viewModel.ManufacturerKey).Select(x => x.Logo).FirstOrDefault();
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
            var model = db.Manufacturer.Where(x => x.ManufacturerKey == id).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new ManufacturerViewModel()
                {
                    ManufacturerKey = model.ManufacturerKey,
                    ManufacturerName = model.ManufacturerName,
                    ManufacturerID = model.ManufacturerID,
                    ManufacturerAddress = model.ManufacturerAddress,
                    CPhone = model.CPhone,
                    CountryOfOrigin = model.CountryOfOrigin,
                    CEmail = model.CEmail,
                    CWebsite = model.CWebsite,
                    CFax = model.CFax,
                    Logo = model.Logo,
                    LogoType = model.LogoType
                };

                return View(viewModel);
            }

        }


        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.Manufacturer.Find(id);
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