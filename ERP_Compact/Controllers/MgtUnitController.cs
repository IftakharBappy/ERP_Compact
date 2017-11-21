using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtUnitController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        // GET: MgtUnit
        public ActionResult Index()
        {
            UnitViewModel model = new UnitViewModel();
            model.UnitList = db.Unit.Where(a => a.IsDelete == false).Select(x => new UnitViewModel()
            {
                UnitKey = x.UnitKey,
                UnitID = x.UnitID,
                UnitName = x.UnitName,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(UnitViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Unit model = new Unit();
                    model.UnitKey = Guid.NewGuid();
                    model.UnitID = obj.UnitID;
                    model.UnitName = obj.UnitName;

                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.UnitID)) model.UnitID = obj.UnitName;

                    db.Unit.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtUnit", "Index"));
            }
        }

        [HttpPost]
        public ActionResult Update(UnitViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Unit model = db.Unit.Find(obj.UnitKey);
                    model.UnitID = obj.UnitID;
                    model.UnitName = obj.UnitName;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.UnitID)) model.UnitID = obj.UnitName;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtUnit", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                Unit model = db.Unit.Find(ID);
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