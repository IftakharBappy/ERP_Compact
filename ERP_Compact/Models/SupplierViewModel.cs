using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERP_Compact.Models
{
    public class SupplierViewModel
    {
        public System.Guid SupplierID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string SupplierName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string SupplierAddress { get; set; }

        [Display(Name = "Phone No")] public string SupplierPhone { get; set; }

        [Display(Name = "Alternate Phone No")]
        public string SupplierMobile { get; set; }

        [Display(Name = "Email")]
        public string SupplierEmail { get; set; }

        [Display(Name = "Website")]
        public string SupplierWebsite { get; set; }

        [Display(Name = "Fax No")]
        public string SupplierFax { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        [Display(Name = "Contact Person Name")]
        public string ContactPersonName { get; set; }

        [Display(Name = "Contact Person contact No")]
        public string ContactPersonNo { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }

        [Display(Name = "Discount %")]
        public Nullable<decimal> DiscountPerc { get; set; }

        [Display(Name = "Discount Amount")]
        public Nullable<decimal> DiscountAmt { get; set; }

        [Display(Name = "Incentive")]
        public Nullable<decimal> Incentive { get; set; }

        [Display(Name = "Upazilla")]
        public Nullable<System.Guid> UpazillaKey { get; set; }

        //# only view properties
        public Nullable<bool> KeepOldLogo { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string UpazillaName { get; set; }
    }
}