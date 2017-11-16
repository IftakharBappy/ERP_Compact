using ERP_Compact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Compact.Controllers
{
    public class MgtDistrictController : Controller
    {
        // GET: MgtDistrict
        ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult Index()
        {
            DistrictViewModel model = new DistrictViewModel();
            model.DistrictList = db.District.Where(a => a.IsDelete == false).Select(x => new DistrictViewModel()
            {
                DistrictKey = x.DistrictKey,
                DistrictID = x.DistrictID,
                DistrictName = x.DistrictName,
                DivisionKey = x.Division.DivisionKey,
                DivisionName = x.Division.DivisionName

            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(DistrictViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    District model = new District();
                    model.DistrictKey = Guid.NewGuid();
                    model.DistrictID = obj.DistrictID;
                    model.DistrictName = obj.DistrictName;
                    model.DivisionKey = obj.DivisionKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.DistrictID)) model.DistrictID = obj.DistrictName;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    db.District.Add(model);
                    db.SaveChanges();

                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtDistrict", "Index"));
            }
        }
        [HttpPost]
        public ActionResult Update(DistrictViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    District model = db.District.Find(obj.DistrictKey);
                    model.DistrictID = obj.DistrictID;
                    model.DistrictName = obj.DistrictName;
                    model.DivisionKey = obj.DivisionKey;
                    model.IsDelete = false;
                    if (string.IsNullOrEmpty(obj.DistrictID)) model.DistrictID = obj.DistrictName;
                    //model.WarehouseKey = GlobalClass.Warehouse.WarehouseKey;
                    db.SaveChanges();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "MgtDistrict", "Index"));
            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                District model = db.District.Find(ID);
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
        public JsonResult LoadDivisionDropDown_ToCreate(Guid? id)
        {
            if (id == Guid.Empty || id == null)
            {
                var list = (from st in db.Division where st.IsDelete == false select new { st.DivisionKey, st.DivisionName, Selected = "" }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var list = (from st in db.Division
                            where st.IsDelete == false
                            select new
                            {
                                st.DivisionKey,
                                st.DivisionName,
                                Selected = st.DivisionKey == id ? "selected" : ""
                            }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LoadDivisionDropDown_ToEdit(Guid? id)
        {
            var list = (from D in db.Division
                        where D.IsDelete == false
                        select new
                        {
                            D.DivisionKey,
                            D.DivisionName,
                            Selected = D.DivisionKey == id ? "selected" : ""
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