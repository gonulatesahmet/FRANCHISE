using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbDiscount : IDTOs
    {
        public int DiscountId { get; set; }
        public string DiscountName { get; set; }
    }
}
