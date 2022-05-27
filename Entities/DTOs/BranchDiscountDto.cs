using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BranchDiscountDto : IDTOs
    {
        public int BranchDiscountId { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int DiscountId { get; set; }
        public string DiscountName { get; set; }
        public int TypeOfDiscountId { get; set; }
        public string TypeOfDiscountName { get; set; }
        public decimal BranchDiscountAmount { get; set; }
        public bool BranchDiscountState { get; set; }
    }
}
