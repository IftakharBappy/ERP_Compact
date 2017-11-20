using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class StoreShelfViewModel
    {
        public System.Guid ShelfKey { get; set; }
        public string ShelfID { get; set; }
        public string ShelfName { get; set; }
        public Nullable<int> ShelfLevel { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }
        public List<StoreShelfViewModel> StoreShelfList { get; set; }
    }
}