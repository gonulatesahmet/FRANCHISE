using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TypeOfDiscount : IEntity
    {
        public int TypeOfDiscountId { get; set; }
        public string TypeOfDiscountName { get; set; }
        public string TypeOfDiscountCode { get; set; }
        public string TypeOfDiscountDescription { get; set; }
        public bool TypeOfDiscountState { get; set; }
    }
}
