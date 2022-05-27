using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Device : IEntity
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceDescription { get; set; }
        public string DeviceMac { get; set; }
        public int InstitutionId { get; set; }
        public int BranchId { get; set; }
        public int TypeOfDeviceId { get; set; }
        public int AreaId { get; set; }
        public bool DeviceState { get; set; }
    }
}
