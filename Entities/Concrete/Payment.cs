using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentNote { get; set; }
        public int TypeOfPaymentId { get; set; }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
        public int EmployeeId { get; set; }
        public bool PaymentState { get; set; }
    }
}
