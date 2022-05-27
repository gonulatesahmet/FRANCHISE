using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DeviceManager : IDeviceService
    {
        IDeviceDal _deviceDal;
        public DeviceManager(IDeviceDal deviceDal)
        {
            _deviceDal = deviceDal;
        }
        public IResult Add(Device entity)
        {
            _deviceDal.Add(entity);
            return new SuccessResult(Messages.DeviceAdded);
        }

        public IResult ChangeState(int id, bool state)
        {
            _deviceDal.ChangeState(id, state);
            return new SuccessResult(Messages.DeviceChangeState);
        }

        public IResult Delete(int id)
        {
            _deviceDal.Delete(id);
            return new SuccessResult(Messages.DeviceDeleted);
        }
        public IDataResult<List<Device>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Device>>(_deviceDal.GetAll(id), Messages.DeviceGetAll);
        }

        public IDataResult<Device> GetById(int id)
        {
            return new SuccessDataResult<Device>(_deviceDal.GetById(id), Messages.DeviceGetById);
        }

        public IResult Update(Device entity)
        {
            _deviceDal.Update(entity);
            return new SuccessResult(Messages.DeviceUpdated);
        }




        public IDataResult<List<DeviceDto>> DeviceDtoGetAll()
        {
            return new SuccessDataResult<List<DeviceDto>>(_deviceDal.DeviceDtoGetAll(), Messages.DeviceGetAll);
        }

        public IDataResult<DeviceDto> DeviceDtoGetByDeviceMac(string deviceMac)
        {
            var result = _deviceDal.DeviceDtoGetByDeviceMac(deviceMac);
            if(result != null)
            {
                return new SuccessDataResult<DeviceDto>(result,Messages.DeviceVerified);
            }
            else
            {
                return new ErrorDataResult<DeviceDto>(Messages.DeviceCouldNotBeVerified);
            }
            
        }
    }
}
