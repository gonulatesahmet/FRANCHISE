using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BranchProduct : IEntity
    {
        public int BranchProductId { get; set; }
        public int ProductId { get; set; }
        public int BranchId { get; set; }
        public decimal BranchProductPrice { get; set; }
        public bool StockStatus { get; set; }
        public bool BranchProductState { get; set; }
    }
}
