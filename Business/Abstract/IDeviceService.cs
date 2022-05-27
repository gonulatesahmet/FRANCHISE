using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDeviceService : IEntityRepositoryBusiness<Device>
    {
        IDataResult<List<DeviceDto>> DeviceDtoGetAll();
        IDataResult<DeviceDto> DeviceDtoGetByDeviceMac(string deviceMac);
    }
}
