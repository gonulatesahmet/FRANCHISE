using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbBranchProduct : IDTOs
    {
        public int BranchProductId { get; set; }
        public string ProductName { get; set; }
    }
}
