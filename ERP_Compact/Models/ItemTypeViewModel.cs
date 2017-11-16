using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class ItemTypeViewModel
    {
        public System.Guid TypeKey { get; set; }
        public string TypeName { get; set; }
        public string TypeID { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Item { get; set; }

        public List<ItemTypeViewModel> ItemTypeList { get; set; }
    }
}