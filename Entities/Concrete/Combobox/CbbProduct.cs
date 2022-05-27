using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbProduct : IDTOs
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
