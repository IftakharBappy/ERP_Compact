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
    
    public partial class Company
    {
        public System.Guid CompanyKey { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyMobile { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyFax { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNo { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> DivisionKey { get; set; }
        public Nullable<System.Guid> DistrictKey { get; set; }
        public Nullable<System.Guid> UpazillaKey { get; set; }
    
        public virtual District District { get; set; }
        public virtual Division Division { get; set; }
        public virtual Upazilla Upazilla { get; set; }
    }
}
