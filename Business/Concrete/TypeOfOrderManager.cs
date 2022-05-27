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
    public class TypeOfOrderManager : ITypeOfOrderService
    {
        ITypeOfOrderDal _typeOfOrderDal;
        public TypeOfOrderManager(ITypeOfOrderDal typeOfOrderDal)
        {
            _typeOfOrderDal = typeOfOrderDal;
        }
        public IResult Add(TypeOfOrder entity)
        {
            _typeOfOrderDal.Add(entity);
            return new SuccessResult(Messages.TypeOfProductAdded);
        }

        public IResult ChangeState(int id, bool state)
        {
            _typeOfOrderDal.ChangeState(id, state);
            return new SuccessResult(Messages.TypeOfProductChangeState);
        }

        public IResult Delete(int id)
        {
            _typeOfOrderDal.Delete(id);
            return new SuccessResult(Messages.TypeOfProductDeleted);
        }

        public IDataResult<List<TypeOfOrder>> GetAll(int? id)
        {
            return new SuccessDataResult<List<TypeOfOrder>>(_typeOfOrderDal.GetAll(id), Messages.TypeOfProductGetAll);
        }

        public IDataResult<TypeOfOrder> GetById(int id)
        {
            return new SuccessDataResult<TypeOfOrder>(_typeOfOrderDal.GetById(id), Messages.TypeOfProductGetById);
        }

        public IResult Update(TypeOfOrder entity)
        {
            _typeOfOrderDal.Update(entity);
            return new SuccessResult(Messages.TypeOfProductUpdated);
        }
        public IDataResult<List<CbbTypeOfOrder>> CbbTypeOfOrderGetAll(bool state)
        {
            return new SuccessDataResult<List<CbbTypeOfOrder>>(_typeOfOrderDal.CbbTypeOfOrderGetAll(state), Messages.TypeOfProductGetAll);
        }

    }
}
