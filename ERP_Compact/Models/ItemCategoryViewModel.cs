using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class ItemCategoryViewModel
    {
        public System.Guid CategoryKey { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }
        public string CategoryID { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSubcategory> ItemSubcategory { get; set; }

        public List<ItemCategoryViewModel> ItemCategoryList { get; set; }
    }
}