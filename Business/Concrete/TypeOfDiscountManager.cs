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
    public class TypeOfDiscountManager : ITypeOfDiscountService
    {
        ITypeOfDiscountDal _typeOfDiscountDal;
        public TypeOfDiscountManager(ITypeOfDiscountDal typeOfDiscountDal)
        {
            _typeOfDiscountDal = typeOfDiscountDal;
        }
        public IResult Add(TypeOfDiscount entity)
        {
            _typeOfDiscountDal.Add(entity);
            return new SuccessResult(Messages.DiscountAdded);
        }

        public IResult ChangeState(int id, bool state)
        {
            _typeOfDiscountDal.ChangeState(id, state);
            return new SuccessResult(Messages.DiscountChangeState);
        }

        public IResult Delete(int id)
        {
            _typeOfDiscountDal.Delete(id);
            return new SuccessResult(Messages.DiscountDeleted);
        }

        public IDataResult<List<TypeOfDiscount>> GetAll(int? id)
        {
            return new SuccessDataResult<List<TypeOfDiscount>>(_typeOfDiscountDal.GetAll(id), Messages.DiscountGetAll);
        }

        public IDataResult<TypeOfDiscount> GetById(int id)
        {
            return new SuccessDataResult<TypeOfDiscount>(_typeOfDiscountDal.GetById(id), Messages.DiscountGetById);
        }

        public IResult Update(TypeOfDiscount entity)
        {
            _typeOfDiscountDal.Update(entity);
            return new SuccessResult(Messages.DiscountUpdated);
        }

        public IDataResult<List<CbbTypeOfDiscount>> CbbTypeOfDiscountGetAll(bool state)
        {
            return new SuccessDataResult<List<CbbTypeOfDiscount>>(_typeOfDiscountDal.CbbTypeOfDiscountGetAll(state), Messages.DiscountGetAll);
        }

    }
}
