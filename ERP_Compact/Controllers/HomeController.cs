using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP_Compact.Models;
using ERP_Compact.DAL;
namespace ERP_Compact.Controllers
{
    public class HomeController : Controller
    {
        ERPMgtEntities db = new ERPMgtEntities();
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        //if (username == "sa" && password == "ntDomain")
        //        //{
        //            GlobalClass.LoginUser = new User();
        //            GlobalClass.LoginUser.PersonName = "Admin";
        //            GlobalClass.LoginUser.NationalID = "Admin";
        //            GlobalClass.LocalString = new System.Globalization.CultureInfo("bn");
        //            Company com = db.Company.FirstOrDefault();
        //        GlobalClass.Warehouse = new Warehouse();
        //        GlobalClass.Warehouse.WarehouseKey = Guid.NewGuid();
        //            if (com == null)
        //            {
        //                GlobalClass.Company = new Company();
        //                GlobalClass.Company.CompanyKey = Guid.NewGuid();
        //            }
        //            else
        //            {
        //                GlobalClass.Company = com;
        //            }

        //            GlobalClass.FormList = new List<UserFormClass>();
        //            GlobalClass.ModuleList = new List<UserModuleClass>();
        //            UserModuleClass obj = new UserModuleClass();
        //            obj.formList = new List<UserFormClass>();
        //            GlobalClass.ModuleList.Add(obj);
        //            GlobalClass.SystemSession = true;
        //            return RedirectToAction("Index", "Home");
        //        //}
        //        //else
        //        //{
        //        //    StaffList obj = db.StaffList.SingleOrDefault(m => m.Username == username && m.Password == password && m.IsUser == true);
        //        //    if (obj == null)
        //        //    {
        //        //        Exception e = new Exception("Incorrect user access.");
        //        //        return View("Error", new HandleErrorInfo(e, "UserLogin", "Login"));
        //        //    }
        //        //    else
        //        //    {
        //        //        GlobalClass.LoginUser = obj;
        //        //        GlobalClass.LocalString = new System.Globalization.CultureInfo("bn");
        //        //        GlobalClass.Company = db.Company.Find(obj.CompanyKey);
        //        //        EM_AdminAccess.SetUserAccess((Guid)obj.Usergr);
        //        //        GlobalClass.SystemSession = true;
        //        //        return RedirectToAction("Index", "UserHome");
        //        //    }
        //        //}

        //    }
        //    catch (Exception e)
        //    {
        //        return View("Error", new HandleErrorInfo(e, "Home", "Index"));
        //    }
        //}

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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