using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class AssetSubcategoryViewModel
    {
        public System.Guid SubcategoryKey { get; set; }
        public string SubcategoryName { get; set; }
        public string SubcategoryID { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> CategoryKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Asset { get; set; }
        public virtual AssetCategory AssetCategory { get; set; }
        public List<AssetSubcategoryViewModel> AssetSubcategoryList { get; set; }

        public string CategoryName { get; set; }
    }
}