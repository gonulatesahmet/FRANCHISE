using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TypeOfDevice : IEntity
    {
        public int TypeOfDeviceId { get; set; }
        public string TypeOfDeviceName { get; set; }
        public string TypeOfDeviceCode { get; set; }
        public string TypeOfDeviceDescription { get; set; }
        public bool TypeOfDeviceState { get; set; }
    }
}
