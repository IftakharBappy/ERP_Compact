using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtModulesController : Controller
    {
        // GET: MgtModules
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            ModulesViewModel model = new ModulesViewModel();
            model.ModulesList = db.Modules.Select(x => new ModulesViewModel()
            {
                ModuleID = x.ModuleID,
                ModuleName = x.ModuleName,
                ModuleLevel = x.ModuleLevel,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ModulesViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Modules model = new Modules();
                    model.ModuleID = Guid.NewGuid();
                    model.ModuleName = obj.ModuleName;
                    model.ModuleLevel = obj.ModuleLevel;

                    db.Modules.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtModules", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(ModulesViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Modules model = db.Modules.Find(obj.ModuleID);
                    model.ModuleName = obj.ModuleName;
                    model.ModuleLevel = obj.ModuleLevel;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtModules", "Index"));
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