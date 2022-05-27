using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbBranchDiscount : IDTOs
    {
        public int BranchDiscountId { get; set; }
        public string BranchDiscountName { get; set; }
    }
}
