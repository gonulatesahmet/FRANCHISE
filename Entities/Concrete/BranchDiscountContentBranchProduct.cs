using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BranchDiscountContentBranchProduct : IEntity
    {
        public int BranchDiscountContentBranchProductId { get; set; }
        public decimal BranchDiscountContentBranchProductPrice { get; set; }
        public int BranchDiscountContentId { get; set; }
        public int BranchProductId { get; set; }
        public bool BranchDiscountContentBranchProductState { get; set; }
    }
}
