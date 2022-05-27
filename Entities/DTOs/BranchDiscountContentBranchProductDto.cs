using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BranchDiscountContentBranchProductDto : IDTOs
    {
        public int BranchDiscountContentBranchProductId { get; set; }
        public int BranchDiscountContentId { get; set; }
        public string BranchDiscountContentName { get; set; }
        public int BranchProductId { get; set; }
        public string BranchProductName { get; set; }
        public decimal BranchDiscountContentBranchProductPrice { get; set; }
        public bool BranchDiscountContentBranchProductState { get; set; }
    }
}
