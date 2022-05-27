using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbBranchDiscountContent : IDTOs
    {
        public int BranchDiscountContentId { get; set; }
        public string BranchDiscountContentName { get; set; }
    }
}
