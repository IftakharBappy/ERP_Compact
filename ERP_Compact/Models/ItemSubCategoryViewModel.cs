using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class ItemSubCategoryViewModel
    {
        public System.Guid SubcategoryKey { get; set; }
        [Required(ErrorMessage = "Sub category Name is required.")]
        public string SubcategoryName { get; set; }
        public string SubcategoryID { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public Nullable<System.Guid> CategoryKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Item { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }

        public List<ItemSubCategoryViewModel> ItemSubCategoryList { get; set; }
        public string CategoryName { get; set; }
    }
}