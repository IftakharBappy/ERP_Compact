using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class ModulesViewModel
    {
        public System.Guid ModuleID { get; set; }
        [Required]
        public string ModuleName { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter Number Only")]
        [Required]
        public Nullable<int> ModuleLevel { get; set; }

        public List<ModulesViewModel> ModulesList { get; set; }
    }
}