using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtSubModuleController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        // GET: MgtSubModule
        public ActionResult Index()
        {
            SubModuleViewModel model = new SubModuleViewModel();
            model.SubModuleList = db.SubModule.Select(x => new SubModuleViewModel()
            {
                SubModuleID = x.SubModuleID,
                ModuleID = x.ModuleID,
                ModuleName = x.Modules.ModuleName,
                SubModuleName = x.SubModuleName,
                SubModuleLevel = x.SubModuleLevel,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(SubModuleViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubModule model = new SubModule();
                    model.SubModuleID = Guid.NewGuid();
                    model.ModuleID = obj.ModuleID;
                    model.SubModuleName = obj.SubModuleName;
                    model.SubModuleLevel = obj.SubModuleLevel;

                    db.SubModule.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtSubModule", "Index"));
            }
        }

        [HttpPost]
        public ActionResult Update(SubModuleViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubModule model = db.SubModule.Find(obj.SubModuleID);
                    model.ModuleID = obj.ModuleID;
                    model.SubModuleName = obj.SubModuleName;
                    model.SubModuleLevel = obj.SubModuleLevel;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtSubModule", "Index"));
            }
        }

        public JsonResult LoadSubModuleDropDown_ToCreate(Guid? id)
        {
            if (id == Guid.Empty || id == null)
            {
                var list = (from st in db.Modules select new { st.ModuleID, st.ModuleName, Selected = "" }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = (from st in db.Modules
                            select new
                            {
                                st.ModuleID,
                                st.ModuleName,
                                Selected = st.ModuleID == id ? "selected" : ""
                            }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LoadSubModuleDropDown_ToEdit(Guid? id)
        {
            var list = (from M in db.Modules
                        select new
                        {
                            M.ModuleID,
                            M.ModuleName,
                            Selected = M.ModuleID == id ? "selected" : ""
                        }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
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