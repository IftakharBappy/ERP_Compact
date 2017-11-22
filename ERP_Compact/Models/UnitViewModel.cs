using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class UnitViewModel
    {
        public System.Guid UnitKey { get; set; }
        public string UnitID { get; set; }
        public string UnitName { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Asset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Item { get; set; }
        public List<UnitViewModel> UnitList { get; set; }
    }
}