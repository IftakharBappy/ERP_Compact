using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class DesignationViewModel
    {
        public System.Guid DesignationKey { get; set; }
        public string DesignationtID { get; set; }
        [Required(ErrorMessage = "Designation Name is required.")]
        public string DesignationName { get; set; }
        public Nullable<int> DesignationLevel { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }

        public List<DesignationViewModel> DesignationList { get; set; }
    }
}