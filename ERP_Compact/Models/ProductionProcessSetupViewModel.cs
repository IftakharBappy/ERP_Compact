using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class ProductionProcessSetupViewModel
    {
        public System.Guid ProcessKey { get; set; }
        public string ProcessID { get; set; }
        public string ProcessName { get; set; }
        public Nullable<int> ProcessLevel { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }

        public List<ProductionProcessSetupViewModel> ProductionProcessSetupList { get; set; }
    }
}