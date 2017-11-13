using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtDepartmentController : Controller
    {
        // GET: MgtDepartment
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            DepartmentViewModel model = new DepartmentViewModel();
            model.DepartmentList = db.Department.Where(a => a.IsDelete == false).Select(x => new DepartmentViewModel()
            {
                DepartmentKey = x.DepartmentKey,
                DepartmentID = x.DepartmentID,
                DepartmentName = x.DepartmentName,

            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(DepartmentViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Department model = new Department();
                    model.DepartmentKey = Guid.NewGuid();
                    model.DepartmentID = obj.DepartmentID;
                    model.DepartmentName = obj.DepartmentName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.DepartmentID)) model.DepartmentID = obj.DepartmentName;

                    db.Department.Add(model);
                    db.SaveChanges();

                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtDepartment", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(DepartmentViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Department model = db.Department.Find(obj.DepartmentKey);
                    model.DepartmentID = obj.DepartmentID;
                    model.DepartmentName = obj.DepartmentName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.DepartmentID)) model.DepartmentID = obj.DepartmentName;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtDepartment", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                Department model = db.Department.Find(ID);
                model.IsDelete = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch
            {
                ModelState.AddModelError(string.Empty, "Some error happened");
                return View(ID);
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