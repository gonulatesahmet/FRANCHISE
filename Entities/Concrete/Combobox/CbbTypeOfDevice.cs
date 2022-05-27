using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Combobox
{
    public class CbbTypeOfDevice : IDTOs
    {
        public int TypeOfDeviceId { get; set; }
        public string TypeOfDeviceName { get; set; }
    }
}
