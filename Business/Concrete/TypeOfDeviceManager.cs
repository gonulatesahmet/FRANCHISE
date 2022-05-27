using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TypeOfDeviceManager : ITypeOfDeviceService
    {
        ITypeOfDeviceDal _typeOfDeviceDal;
        public TypeOfDeviceManager(ITypeOfDeviceDal typeOfDeviceDal)
        {
            _typeOfDeviceDal = typeOfDeviceDal;
        }
        public IResult Add(TypeOfDevice entity)
        {
            _typeOfDeviceDal.Add(entity);
            return new SuccessResult(Messages.TypeOfDeviceAdded);
        }
        public IResult ChangeState(int id, bool state)
        {
            _typeOfDeviceDal.ChangeState(id, state);
            return new SuccessResult(Messages.TypeOfDeviceChangeState);
        }

        public IResult Delete(int id)
        {
            _typeOfDeviceDal.Delete(id);
            return new SuccessResult(Messages.TypeOfDeviceDeleted);
        }

        public IDataResult<List<TypeOfDevice>> GetAll(int? id)
        {
            return new SuccessDataResult<List<TypeOfDevice>>(_typeOfDeviceDal.GetAll(id), Messages.TypeOfDeviceGetAll);
        }

        public IDataResult<TypeOfDevice> GetById(int id)
        {
            return new SuccessDataResult<TypeOfDevice>(_typeOfDeviceDal.GetById(id), Messages.TypeOfDeviceGetById);
        }

        public IResult Update(TypeOfDevice entity)
        {
            _typeOfDeviceDal.Update(entity);
            return new SuccessResult(Messages.TypeOfDeviceUpdated);
        }

        public IDataResult<List<CbbTypeOfDevice>> CbbTypeOfDeviceGetAll(bool TypeOfDeviceState)
        {
            return new SuccessDataResult<List<CbbTypeOfDevice>>(_typeOfDeviceDal.CbbTypeOfDeviceGetAll(TypeOfDeviceState));
        }
    }
}
