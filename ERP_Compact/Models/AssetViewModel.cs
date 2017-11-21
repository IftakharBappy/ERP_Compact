using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ERP_Compact.Models
{
    public class AssetViewModel
    {
        public System.Guid ItemKey { get; set; }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "ID is required")]
        public string ItemID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string ItemName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Product ID")]
        public string ProductID { get; set; }
        public byte[] Logo { get; set; }
        public string Logotype { get; set; }

        [Display(Name = "Unit")]
        public Nullable<System.Guid> UnitKey { get; set; }

        [Display(Name = "Unit Size")]
        public Nullable<decimal> Unitsize { get; set; }

        [Display(Name = "Category")]
        public Nullable<System.Guid> CategoryKey { get; set; }

        [Display(Name = "Subcategory")]
        public Nullable<System.Guid> SubcategoryKey { get; set; }

        [Display(Name = "Model No")]
        public string ModelNo { get; set; }

        [Display(Name = "Item Color")]
        public string ItemColor { get; set; }

        [Display(Name = "Reorder Level")]
        public Nullable<decimal> ReorderLevel { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        [Display(Name = "Division")]
        public Nullable<System.Guid> ManufacturerKey { get; set; }

        [Display(Name = "Start Year")]
        public Nullable<int> StartYear { get; set; }

        [Display(Name = "Depreciation Factor")]
        public Nullable<decimal> DepreciationFactor { get; set; }

        [Display(Name = "Asset Life")]
        public Nullable<decimal> AssetLife { get; set; }

        //# only view properties
        public Nullable<bool> KeepOldLogo { get; set; }
        public string AssetCategoryName { get; set; }
        public string AssetSubcategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public string UnitName { get; set; }
    }
}