using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP_Compact.Models;

namespace ERP_Compact.Controllers
{
    public class BaseController : Controller
    {
        public ERPMgtEntities db = new ERPMgtEntities();
        
        /// <summary>
        /// show meassage on the begining of the page with GREEN background
        /// </summary>
        /// <param name="message"></param>
        public void RenderSuccessMessage(string message)
        {
            TempData["message_background"] = "bg-success";
            TempData["message_text"] = message;
        }

        /// <summary>
        /// show meassage on the begining of the page with Blue background
        /// </summary>
        /// <param name="message"></param>
        public void RenderInfoMessage(string message)
        {
            TempData["message_background"] = "bg-info";
            TempData["message_text"] = message;
        }

        /// <summary>
        /// show meassage on the begining of the page with RED background
        /// </summary>
        /// <param name="message"></param>
        public void RenderDangerMessage(string message)
        {
            TempData["message_background"] = "bg-danger";
            TempData["message_text"] = message;
        }
    }
}