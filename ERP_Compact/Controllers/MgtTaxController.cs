using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtTaxController : Controller
    {
        // GET: MgtTax
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            TaxViewModel model = new TaxViewModel();
            model.TaxList = db.Tax.Select(x => new TaxViewModel()
            {
                TaxKey = x.TaxKey,
                TaxID = x.TaxID,
                Amt = x.Amt,
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(TaxViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tax model = new Tax();
                    model.TaxKey = Guid.NewGuid();
                    model.TaxID = obj.TaxID;
                    model.Amt = obj.Amt;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    db.Tax.Add(model);
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtTax", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(TaxViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tax model = db.Tax.Find(obj.TaxKey);
                    model.TaxID = obj.TaxID;
                    model.Amt = obj.Amt;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;

                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtTax", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                Tax model = db.Tax.Find(ID);
                db.Tax.Remove(model);
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