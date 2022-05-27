using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbTypeOfDiscount : IDTOs
    {
        public int TypeOfDiscountId { get; set; }
        public string TypeOfDiscountName { get; set; }
    }
}
