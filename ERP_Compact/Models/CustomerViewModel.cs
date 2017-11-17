using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERP_Compact.Models
{
    public class CustomerViewModel
    {
        public System.Guid CustomerKey { get; set; }
        public System.Guid WarehouseKey { get; set; }

        [Display(Name = "ID")]
        public string CustomeID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string CustomerName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string CustomeAddress { get; set; }

        [Display(Name = "Phone No")]
        public string CPhone { get; set; }

        [Display(Name = "Alternate Phone No")]
        public string CMobile { get; set; }

        [Display(Name = "Email")]
        public string CEmail { get; set; }

        [Display(Name = "Website")]
        public string CWebsite { get; set; }

        [Display(Name = "Fax No")]
        public string CFax { get; set; }

        [Display(Name = "Contact Person Name")]
        public string ContactPersonName { get; set; }

        [Display(Name = "Contact Person contact No")]
        public string ContactPersonNo { get; set; }

        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
        public Nullable<bool> IsDelete { get; set; }

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