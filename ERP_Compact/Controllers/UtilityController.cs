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