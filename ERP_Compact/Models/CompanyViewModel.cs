using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERP_Compact.Models
{
    public class CompanyViewModel
    {
        public System.Guid CompanyKey { get; set; }
        [Display(Name = "ID")]
        public string CompanyID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Phone No")]
        public string CompanyPhone { get; set; }

        [Display(Name = "Alternate Phone No")]
        public string CompanyMobile { get; set; }


        [Display(Name = "Email")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Website")]
        public string CompanyWebsite { get; set; }

        [Display(Name = "Fax No")]
        public string CompanyFax { get; set; }

        [Display(Name = "Contact Person Name")]
        public string ContactPersonName { get; set; }


        [Display(Name = "Contact Person contact No")]
        public string ContactPersonNo { get; set; }

        
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        [Display(Name = "Division")]
        public Nullable<System.Guid> DivisionKey { get; set; }

        [Display(Name = "District")]
        public Nullable<System.Guid> DistrictKey { get; set; }

        [Display(Name = "Upazilla")]
        public Nullable<System.Guid> UpazillaKey { get; set; }


        //# only view properties
        public Nullable<bool> KeepOldLogo { get; set; }
        
        public string DivisionName { get; set; }

        public string DistrictName { get; set; }

        public string UpazillaName { get; set; }
    }
}