using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class FormsViewModel
    {
        public System.Guid FormID { get; set; }
        [Required(ErrorMessage = "Module Name is required.")]
        public System.Guid ModuleID { get; set; }
        [Required(ErrorMessage = "Module Name is required.")]
        public string FormName { get; set; }
        [Required(ErrorMessage = "Form Name is required.")]
        public Nullable<int> FormLevel { get; set; }
        [Required(ErrorMessage = "FormLevel is required.")]
        public string FormController { get; set; }
        [Required(ErrorMessage = "ViewName is required.")]
        public string ViewName { get; set; }
        public Nullable<System.Guid> SubModuleID { get; set; }

        public virtual Modules Modules { get; set; }
        public virtual SubModule SubModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsergroupToForm> UsergroupToForm { get; set; }

        public List<FormsViewModel> FormsViewModelList { get; set; }
        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
    }
}