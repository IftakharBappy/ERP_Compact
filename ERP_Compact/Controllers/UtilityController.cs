using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP_Compact.Models;
using Newtonsoft.Json;
using ERP_Compact.DAL;
using System.Text;


namespace ERP_Compact.Controllers
{
    public class UtilityController : Controller
    {
        // GET: Utility
        private ERPMgtEntities db = new ERPMgtEntities();
        public ActionResult LoadDivision(Guid SelectID)
        {
            JsonResult result = new JsonResult();
            GISclass obj = new GISclass();
            Division m = db.Division.Find(SelectID);
            obj.DivisionKey = m.DivisionKey;
            obj.DivisionID = m.DivisionID;
            obj.DivisionName = m.DivisionName;

            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public JsonResult GetDistrictsOfDivision (Guid divisionKey)
        {
            var res = db.District.Where(d => d.DivisionKey == divisionKey && d.IsDelete == false).Select( x=> new { x.DistrictKey, x.DistrictName }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUpazillasOfDistrict(Guid districtKey)
        {
            var res = db.Upazilla.Where(d => d.DistrictKey == districtKey && d.IsDelete == false).Select(x => new { x.UpazillaKey, x.UpazillaName }).ToList();
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