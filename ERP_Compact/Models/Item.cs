//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_Compact.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public System.Guid ItemKey { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string ProductID { get; set; }
        public byte[] logo { get; set; }
        public Nullable<System.Guid> UnitKey { get; set; }
        public Nullable<decimal> Unitsize { get; set; }
        public Nullable<System.Guid> CategoryKey { get; set; }
        public Nullable<System.Guid> SubcategoryKey { get; set; }
        public Nullable<System.Guid> TypeKey { get; set; }
        public string ModelNo { get; set; }
        public string ItemColor { get; set; }
        public Nullable<decimal> ReorderLevel { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemSubcategory ItemSubcategory { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual Unit Unit { get; set; }
    }
}