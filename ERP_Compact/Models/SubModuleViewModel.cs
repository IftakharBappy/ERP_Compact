using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class SubModuleViewModel
    {
        public System.Guid SubModuleID { get; set; }
        public System.Guid ModuleID { get; set; }
        [Required(ErrorMessage = "SubModule Name is required.")]
        public string SubModuleName { get; set; }
        [Required(ErrorMessage = "SubModule Level is required.")]
        public Nullable<int> SubModuleLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Forms> Forms { get; set; }
        public virtual Modules Modules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsergroupToSubmodule> UsergroupToSubmodule { get; set; }

        public List<SubModuleViewModel> SubModuleList { get; set; }
        public string ModuleName { get; set; }
    }
}