using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class DepartmentViewModel
    {

        public System.Guid DepartmentKey { get; set; }
        public string DepartmentID { get; set; }
        [Required(ErrorMessage = " Name is required.")]
        public string DepartmentName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }

        public List<DepartmentViewModel> DepartmentList { get; set; }
    }
}