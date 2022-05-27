using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BranchDiscountContent : IEntity
    {
        public int BranchDiscountContentId { get; set; }
        public string BranchDiscountContentName { get; set; }
        public string BranchDiscountContentCode { get; set; }
        public string BranchDiscountContentDescription { get; set; }
        public int BranchDiscountId { get; set; }
        public bool BranchDiscountContentState { get; set; }

    }
}
