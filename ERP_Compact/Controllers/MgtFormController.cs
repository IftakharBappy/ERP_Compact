using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtFormController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        // GET: MgtForm
        public ActionResult Index()
        {
            FormsViewModel model = new FormsViewModel();
            model.FormsViewModelList = db.Forms.Select(x => new FormsViewModel()
            {
                FormID = x.FormID,
                ModuleID = x.ModuleID,
                ModuleName = x.Modules.ModuleName,
                FormName = x.FormName,
                FormLevel = x.FormLevel,
                FormController = x.FormController,
                ViewName = x.ViewName,
                SubModuleName = x.SubModule.SubModuleName,
                

            }).ToList();

            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModuleName", model.ModuleID);
            ViewBag.SubModuleID = new SelectList(db.SubModule, "SubModuleID", "SubModuleName", model.SubModuleID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(FormsViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Forms model = new Forms();
                    model.FormID = Guid.NewGuid();
                    model.ModuleID = obj.ModuleID;
                    model.FormName = obj.FormName;
                    model.FormLevel = obj.FormLevel;
                    model.FormController = obj.FormController;
                    model.ViewName = obj.ViewName;
                    model.SubModuleID = obj.SubModuleID;

                    db.Forms.Add(model);
                    db.SaveChanges();

                    ViewBag.ModuleName = new SelectList(db.Modules, "ModuleID", "ModuleName", obj.ModuleID);
                    ViewBag.SubModuleName = new SelectList(db.SubModule, "SubModuleID", "SubModuleName", obj.SubModuleID);
                }
                    return Json(obj, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "MgtForm", "Index"));
                }
 
               
            }

        [HttpPost]
        public ActionResult Update(FormsViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Forms model = db.Forms.Find(obj.FormID);
                    model.ModuleID = obj.ModuleID;
                    model.FormName = obj.FormName;
                    model.FormLevel = obj.FormLevel;
                    model.FormController = obj.FormController;
                    model.ViewName = obj.ViewName;
                    model.SubModuleID = obj.SubModuleID;
                    db.SaveChanges();

                    ViewBag.ModuleName = new SelectList(db.Modules, "ModuleID", "ModuleName", obj.ModuleID);
                    ViewBag.SubModuleName = new SelectList(db.SubModule, "SubModuleID", "SubModuleName", obj.SubModuleID);
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtDistrict", "Index"));
            }
        }
        public JsonResult ModuleDropDownToCreate(Guid id)
        {
            var res = db.SubModule.Where(d => d.ModuleID == id).Select(x => new { x.SubModuleID, x.SubModuleName }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
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