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
    public class MgtUserController : BaseController
    {
        public ActionResult Index()
        {
            var list = db.User.Where(x => x.IsDelete == false).Include(x => x.Designation).Select(model =>
                 new UserViewModel()
                 {
                     UserKey = model.UserKey,
                     DesignationName = model.DesignationKey != null ? model.Designation.DesignationName : "n/a",
                     DepartmentName = model.DepartmentKey != null ? model.Department.DepartmentName : "n/a",
                 }).ToList();
            return View(list);
        }


        public ActionResult Create()
        {
            ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");
            ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// to send and empty list
            ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// to send and empty list
            ViewBag.DepartmentKey = new SelectList(db.Department.Where(x => x.IsDelete == false), "UpazillaKey", "UpazillaID");// #todo manage later
            ViewBag.DesignationKey = new SelectList(db.Designation.Where(x => x.IsDelete == false), "UpazillaKey", "UpazillaID");// #todo manage later
            ViewBag.Gender = new SelectList(new Dictionary<string, string>() { { "Male", "Male" }, { "Female", "Female" } }, "Key", "Value");
            ViewBag.GroupKey = new SelectList(db.Usergroup, "GroupKey", "GroupName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Logo")] UserViewModel viewModel, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new User();
                    model.IsDelete = false;
                    model.UserKey = Guid.NewGuid();
                    model.WarhouseKey = GlobalClass.Warehouse.WarehouseKey;

                    model.DesignationKey = viewModel.DesignationKey;
                    model.DepartmentKey = viewModel.DepartmentKey;
                    model.Gender = viewModel.Gender;
                    model.PersonName = viewModel.Gender;
                    model.Address = viewModel.Address;
                    model.Phone = string.IsNullOrEmpty(viewModel.Phone) ? "n/a" : viewModel.Phone;
                    model.NationalID = string.IsNullOrEmpty(viewModel.NationalID) ? "n/a" : viewModel.NationalID;
                    model.Email = string.IsNullOrEmpty(viewModel.Email) ? "n/a" : viewModel.Email;
                    model.RegistrationDate = viewModel.RegistrationDate;
                    model.BloodGroup = string.IsNullOrEmpty(viewModel.BloodGroup) ? "n/a" : viewModel.BloodGroup;
                    model.EmergencyPhone = string.IsNullOrEmpty(viewModel.EmergencyPhone) ? "n/a" : viewModel.EmergencyPhone;
                    model.Relationship = string.IsNullOrEmpty(viewModel.Relationship) ? "n/a" : viewModel.Relationship;


                    byte[] imgBinaryData = new byte[Logo.ContentLength];
                    int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                    model.Pic = imgBinaryData;
                    model.pictype = Logo.ContentType;

                    model.Username = string.IsNullOrEmpty(viewModel.Username) ? "n/a" : viewModel.Username;
                    model.Password = string.IsNullOrEmpty(viewModel.Password) ? "n/a" : viewModel.Password;
                    model.GroupKey = viewModel.GroupKey;
                    model.UpazillaKey = viewModel.UpazillaKey;

                    db.User.Add(model);
                    db.SaveChanges();
                    RenderSuccessMessage("User is successfully created.");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("User could not be created due to an error.");
                }

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.DivisionKey = new SelectList(db.Division.Where(x => x.IsDelete == false), "DivisionKey", "DivisionID");// #todo manage later
                ViewBag.DistrictKey = new SelectList(db.District.Where(x => x.DistrictKey == null), "DistrictKey", "DistrictID");// #todo manage later
                ViewBag.UpazillaKey = new SelectList(db.Upazilla.Where(x => x.UpazillaKey == null), "UpazillaKey", "UpazillaID");// #todo manage later
                ViewBag.DepartmentKey = new SelectList(db.Department.Where(x => x.IsDelete == false), "UpazillaKey", "UpazillaID");// #todo manage later
                ViewBag.DesignationKey = new SelectList(db.Designation.Where(x => x.IsDelete == false), "UpazillaKey", "UpazillaID");// #todo manage later
                ViewBag.Gender = new SelectList(new Dictionary<string, string>() { { "Male", "Male" }, { "Female", "Female" } }, "Key", "Value");// #todo manage later
                ViewBag.GroupKey = new SelectList(db.Usergroup, "GroupKey", "GroupName", viewModel.GroupKey);
                return View(viewModel);
            }

        }



        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = db.User.Where(x => x.UserKey == id).Select(model => new UserViewModel()
            {

                DesignationKey = model.DesignationKey,
                DepartmentKey = model.DepartmentKey,
                Gender = model.Gender,
                PersonName = model.Gender,
                Address = model.Address,
                Phone = model.Phone,
                NationalID = model.NationalID,
                Email = model.Email,
                RegistrationDate = model.RegistrationDate,
                BloodGroup = model.BloodGroup,
                EmergencyPhone = model.EmergencyPhone,
                Relationship = model.Relationship,
                Pic = model.Pic,
                pictype = model.pictype,
                Username = model.Username,
                Password = model.Password,
                GroupKey = model.GroupKey,
                UpazillaKey = model.UpazillaKey,
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
            ViewBag.DesignationKey = new SelectList(db.Designation.Where(x => x.IsDelete == false), "UpazillaKey", "UpazillaID", viewModel.DesignationKey);// #todo manage later
            ViewBag.Gender = new SelectList(new Dictionary<string, string>() { { "Male", "Male" }, { "Female", "Female" } }, "Key", "Value", viewModel.Gender);
            ViewBag.GroupKey = new SelectList(db.Usergroup, "GroupKey", "GroupName", viewModel.GroupKey);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Logo")] UserViewModel viewModel, HttpPostedFileBase Logo)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.User.Where(x => x.UserKey == viewModel.UserKey).FirstOrDefault();


                    model.DesignationKey = viewModel.DesignationKey;
                    model.DepartmentKey = viewModel.DepartmentKey;
                    model.Gender = viewModel.Gender;
                    model.PersonName = viewModel.Gender;
                    model.Address = viewModel.Address;
                    model.Phone = string.IsNullOrEmpty(viewModel.Phone) ? "n/a" : viewModel.Phone;
                    model.NationalID = string.IsNullOrEmpty(viewModel.NationalID) ? "n/a" : viewModel.NationalID;
                    model.Email = string.IsNullOrEmpty(viewModel.Email) ? "n/a" : viewModel.Email;
                    model.RegistrationDate = viewModel.RegistrationDate;
                    model.BloodGroup = string.IsNullOrEmpty(viewModel.BloodGroup) ? "n/a" : viewModel.BloodGroup;
                    model.EmergencyPhone = string.IsNullOrEmpty(viewModel.EmergencyPhone) ? "n/a" : viewModel.EmergencyPhone;
                    model.Relationship = string.IsNullOrEmpty(viewModel.Relationship) ? "n/a" : viewModel.Relationship;

                    if (viewModel.KeepOldLogo == false)
                    {
                        byte[] imgBinaryData = new byte[Logo.ContentLength];
                        int readresult = Logo.InputStream.Read(imgBinaryData, 0, Logo.ContentLength);
                        model.Pic = imgBinaryData;
                        model.pictype = Logo.ContentType;
                    }
                    model.Username = string.IsNullOrEmpty(viewModel.Username) ? "n/a" : viewModel.Username;
                    model.Password = string.IsNullOrEmpty(viewModel.Password) ? "n/a" : viewModel.Password;
                    model.GroupKey = viewModel.GroupKey;
                    model.UpazillaKey = viewModel.UpazillaKey;
                    db.SaveChanges();
                    RenderSuccessMessage("User is successfully Updated.");
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    RenderDangerMessage("User could not be updated due to an error.");
                    return RedirectToAction("Edit", new { id = viewModel.UserKey });
                }
            }
            else
            {
                viewModel.Pic = db.User.Where(x => x.UserKey == viewModel.UserKey).Select(x => x.Pic).FirstOrDefault();
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

                ViewBag.DesignationKey = new SelectList(db.Designation.Where(x => x.IsDelete == false), "UpazillaKey", "UpazillaID", viewModel.DesignationKey);// #todo manage later
                ViewBag.Gender = new SelectList(new Dictionary<string, string>() { { "Male", "Male" }, { "Female", "Female" } }, "Key", "Value", viewModel.Gender);
                ViewBag.GroupKey = new SelectList(db.Usergroup, "GroupKey", "GroupName", viewModel.GroupKey);
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
            var model = db.User.Where(x => x.UserKey == id).Include(x => x.Upazilla).Include(x => x.Upazilla.District).Include(x => x.Upazilla.District.Division).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new UserViewModel()
                {
                    DesignationKey = model.DesignationKey,
                    DepartmentKey = model.DepartmentKey,
                    Gender = model.Gender,
                    PersonName = model.Gender,
                    Address = model.Address,
                    Phone = model.Phone,
                    NationalID = model.NationalID,
                    Email = model.Email,
                    RegistrationDate = model.RegistrationDate,
                    BloodGroup = model.BloodGroup,
                    EmergencyPhone = model.EmergencyPhone,
                    Relationship = model.Relationship,
                    Pic = model.Pic,
                    pictype = model.pictype,
                    Username = model.Username,
                    Password = model.Password,
                    GroupKey = model.GroupKey,
                    UpazillaKey = model.UpazillaKey,
                };

                viewModel.DivisionName = model.Upazilla.District.Division != null ? model.Upazilla.District.Division.DivisionName : "n/a";
                viewModel.DistrictName = model.Upazilla.District != null ? model.Upazilla.District.DistrictName : "n/a";
                viewModel.UpazillaName = model.Upazilla != null ? model.Upazilla.UpazillaName : "n/a";
                viewModel.DesignationName = model.DesignationKey != null ? model.Designation.DesignationName : "n/a";
                viewModel.DepartmentName = model.DepartmentKey != null ? model.Department.DepartmentName : "n/a";
                viewModel.GroupName = model.GroupKey != null ? db.Usergroup.Where(x => x.GroupKey == model.GroupKey).Select(x => x.GroupName).FirstOrDefault() : "n/a";
                return View(viewModel);
            }

        }


        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.User.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            try
            {
                model.IsDelete = true;
                db.SaveChanges();
                RenderSuccessMessage("User is successfully deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                RenderDangerMessage("User could not be deleted due to an error.");
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