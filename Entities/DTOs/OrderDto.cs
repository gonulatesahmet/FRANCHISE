using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.OrderStateEnum;

namespace Entities.DTOs
{
    public class OrderDto : IDTOs
    {
        public int OrderId { get; set; }
        public int SessionId { get; set; }
        public DateTime OrderDate { get; set; }
        public int BranchDiscountContentId { get; set; }
        public string BranchDiscountContentName { get; set; }
        public int BranchProductId { get; set; }
        public string ProductName { get; set; }
        public int OrderPiece { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public string OrderNote { get; set; }
        public int TypeOfOrderId { get; set; }
        public string TypeOfOrderName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public OrderState OrderState { get; set; }
    }
}
