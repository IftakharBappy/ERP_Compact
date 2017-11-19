using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERP_Compact.Models
{
    public class ManufacturerViewModel
    {
        public System.Guid ManufacturerKey { get; set; }

        [Display(Name = "ID")]
        public string ManufacturerID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string ManufacturerAddress { get; set; }

        [Display(Name = "Country Of Origin")]
        public string CountryOfOrigin { get; set; }

        [Display(Name = "Phone No")]
        public string CPhone { get; set; }

        [Display(Name = "Email")]
        public string CEmail { get; set; }

        [Display(Name = "Website")]
        public string CWebsite { get; set; }

        [Display(Name = "Fax No")]
        public string CFax { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        //# only view properties
        public Nullable<bool> KeepOldLogo { get; set; }
    }
}