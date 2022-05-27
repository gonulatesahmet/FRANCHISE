using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbTypeOfProduct : IDTOs
    {
        public int TypeOfProductId { get; set; }
        public string TypeOfProductName { get; set; }
    }
}
