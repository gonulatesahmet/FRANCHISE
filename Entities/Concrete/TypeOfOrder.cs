using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TypeOfOrder : IEntity
    {
        public int TypeOfOrderId { get; set; }
        public string TypeOfOrderName { get; set; }
        public string TypeOfOrderCode { get; set; }
        public string TypeOfOrderDescription { get; set; }
        public bool TypeOfOrderState { get; set; }
    }
}
