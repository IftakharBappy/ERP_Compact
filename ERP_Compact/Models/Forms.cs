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
    
    public partial class Forms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Forms()
        {
            this.UsergroupToForm = new HashSet<UsergroupToForm>();
        }
    
        public System.Guid FormID { get; set; }
        public System.Guid ModuleID { get; set; }
        public string FormName { get; set; }
        public Nullable<int> FormLevel { get; set; }
        public string FormController { get; set; }
        public string ViewName { get; set; }
        public Nullable<System.Guid> SubModuleID { get; set; }
    
        public virtual Modules Modules { get; set; }
        public virtual SubModule SubModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsergroupToForm> UsergroupToForm { get; set; }
    }
}