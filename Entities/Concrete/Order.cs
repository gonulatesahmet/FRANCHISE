using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.OrderStateEnum;
using static Entities.Enums.ProductSortEnum;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int SessionId { get; set; }
        public int BranchDiscountContentId { get; set; }
        public DateTime OrderDate { get; set; }
        public int BranchProductId { get; set; }
        public int Piece { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderNote { get; set; }
        public int TypeOfOrderId { get; set; }
        public int EmployeeId { get; set; }
        public int BranchId { get; set; }
        public OrderState OrderState { get; set; }
    }
}
