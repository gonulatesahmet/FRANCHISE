using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Discount : IEntity
    {
        public int DiscountId { get; set; }
        public string DiscountName { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountDescription { get; set; }
        public decimal DiscountAmount { get; set; }
        public int TypeOfDiscountId { get; set; }
        public bool DiscountState { get; set; }
    }
}
