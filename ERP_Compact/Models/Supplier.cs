//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_Compact.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public System.Guid SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierMobile { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierWebsite { get; set; }
        public string SupplierFax { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNo { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
        public Nullable<decimal> DiscountPerc { get; set; }
        public Nullable<decimal> DiscountAmt { get; set; }
        public Nullable<decimal> Incentive { get; set; }
        public Nullable<System.Guid> UpazillaKey { get; set; }
    
        public virtual Upazilla Upazilla { get; set; }
    }
}
