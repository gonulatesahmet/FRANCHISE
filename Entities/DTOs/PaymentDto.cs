using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PaymentDto : IDTOs
    {
        public int PaymentId { get; set; }
        public int SessionId { get; set; }
        public int TypeOfPaymentId { get; set; }
        public string TypeOfPaymentName { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentNote { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool PaymentState { get; set; }
    }
}
