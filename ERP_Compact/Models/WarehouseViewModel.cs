using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ERP_Compact.Models
{
    public class WarehouseViewModel
    {
        public System.Guid WarehouseKey { get; set; }

        [Display(Name = "ID")]
        public string WahouseID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string WahouseName { get; set; }

        [Display(Name = "Address")]
        public string WahouseAddress { get; set; }

        [Display(Name = "Phone No")]
        public string WahousePhone { get; set; }

        [Display(Name = "Alternate Phone No")]
        public string WahouseMobile { get; set; }

        [Display(Name = "Email")]
        public string WahouseEmail { get; set; }

        [Display(Name = "Website")]
        public string WahouseWebsite { get; set; }

        [Display(Name = "Fax No")]
        public string WahouseFax { get; set; }

        [Display(Name = "Contact Person Name")]
        public string ContactPersonName { get; set; }

        [Display(Name = "Contact Person Contact No")]
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