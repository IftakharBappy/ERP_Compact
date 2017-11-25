using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class UserViewModel
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

        public virtual Upazilla Upazilla { get; set; }

        //# only view properties
        public Nullable<bool> KeepOldLogo { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string UpazillaName { get; set; }
        public string GroupName { get; set; }
    }
}