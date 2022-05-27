using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbTypeOfOrder : IDTOs
    {
        public int TypeOfOrderId { get; set; }
        public string TypeOfOrderName { get; set; }
    }
}
