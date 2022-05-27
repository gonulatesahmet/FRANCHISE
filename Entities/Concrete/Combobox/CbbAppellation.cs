using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbAppellation : IDTOs
    {
        public int AppellationId { get; set; }
        public string AppellationName { get; set; }
    }
}
