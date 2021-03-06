﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class AisleViewModel
    {
        public System.Guid AisleKey { get; set; }
        public string AisleID { get; set; }
        [Required(ErrorMessage = "Aisle Name is required.")]
        public string AisleName { get; set; }
        public Nullable<int> AisleLevel { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }
        public List<AisleViewModel> AisleList { get; set; }
    }
}