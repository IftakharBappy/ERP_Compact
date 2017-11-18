using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class StoreRowsViewModel
    {
        public System.Guid RowKey { get; set; }
        public string RowID { get; set; }
        [Required(ErrorMessage = "RowID is required.")]
        public string RowName { get; set; }
        [Required(ErrorMessage = "Row Level is required.")]
        public Nullable<int> RowLevel { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }

        public List<StoreRowsViewModel> StoreRowsList { get; set; }
    }
}