using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class TaxViewModel
    {
        public System.Guid TaxKey { get; set; }
        [Required(ErrorMessage = "Taz ID is required.")]
        public string TaxID { get; set; }
        [Required(ErrorMessage = "Amount is required.")]
        public Nullable<decimal> Amt { get; set; }
        public Nullable<System.Guid> WarehouseKey { get; set; }
        public List<TaxViewModel> TaxList { get; set; }
    }
}