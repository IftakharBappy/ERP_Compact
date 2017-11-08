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
    
    public partial class User
    {
        public System.Guid UserKey { get; set; }
        public Nullable<System.Guid> DesignationKey { get; set; }
        public Nullable<System.Guid> DepartmentKey { get; set; }
        public string PersonName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<System.Guid> UpazillaKey { get; set; }
        public string NationalID { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyPhone { get; set; }
        public string Relationship { get; set; }
        public byte[] Pic { get; set; }
        public string pictype { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Nullable<System.Guid> WarhouseKey { get; set; }
        public Nullable<System.Guid> GroupKey { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Upazilla Upazilla { get; set; }
    }
}