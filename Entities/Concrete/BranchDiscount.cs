using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BranchDiscount : IEntity
    {
        public int BranchDiscountId { get; set; }
        public int BranchId { get; set; }
        public int DiscountId { get; set; }
        public int TypeOfDiscountId { get; set; }
        public decimal BranchDiscountAmount { get; set; }
        public bool BranchDiscountState { get; set; }
    }
}
