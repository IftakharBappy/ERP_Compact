using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class GISclass
    {
        public Guid? DivisionKey { get; set; }
        [Display(Name = "ID")]
        public string DivisionID { get; set; }
        [Display(Name = "Name*")]
        public string DivisionName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public List<GISclass> ModuleList { get; set; }
    }
}