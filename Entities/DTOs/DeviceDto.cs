using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DeviceDto : IDTOs
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceDescription { get; set; }
        public string DeviceMac { get; set; }
        public string BranchName { get; set; }
        public string AreaName { get; set; }
        public string TypeOfDeviceName { get; set; }
        public bool DeviceState { get; set; }
        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public int BranchId { get; set; }
        public int TypeOfDeviceId { get; set; }
        public int AreaId { get; set; }
    }
}
