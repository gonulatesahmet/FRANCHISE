using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TypeOfPayment : IEntity
    {
        public int TypeOfPaymentId { get; set; }
        public string TypeOfPaymentName { get; set; }
        public string TypeOfPaymentCode { get; set; }
        public string TypeOfPaymentDescription { get; set; }
        public bool TypeOfPaymentState { get; set; }
    }
}
