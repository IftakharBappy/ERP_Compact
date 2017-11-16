using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class DistrictViewModel
    {
        public System.Guid DistrictKey { get; set; }
        public string DistrictID { get; set; }
        public string DistrictName { get; set; }
        public Nullable<System.Guid> DivisionKey { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Company { get; set; }
        public virtual Division Division { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Upazilla> Upazilla { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouse { get; set; }

        public List<DistrictViewModel> DistrictList { get; set; }
        public string DivisionName { get; set; }
    }
}