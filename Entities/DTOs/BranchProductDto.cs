using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BranchProductDto : IDTOs
    {
        public int BranchProductId { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal BranchProductPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TypeOfProductId { get; set; }
        public string TypeOfProductName { get; set; }
        public bool StockStatus { get; set; }
        public bool BranchProductState { get; set; }
    }
}
