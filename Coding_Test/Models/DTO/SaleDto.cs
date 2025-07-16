using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Test.Models.DTO
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? Total => Quantity * UnitPrice;
    }
}
