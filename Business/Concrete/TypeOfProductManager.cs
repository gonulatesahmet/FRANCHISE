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
    public class TypeOfProductManager : ITypeOfProductService
    {
        ITypeOfProductDal _typeOfProductDal;
        public TypeOfProductManager(ITypeOfProductDal typeOfProductDal)
        {
            _typeOfProductDal = typeOfProductDal;
        }

        public IResult Add(TypeOfProduct entity)
        {
            _typeOfProductDal.Add(entity);
            return new SuccessResult(Messages.TypeOfProductAdded);
        }

        public IDataResult<List<CbbTypeOfProduct>> CbbTypeOfProductGetAll(bool state)
        {
            return new SuccessDataResult<List<CbbTypeOfProduct>>(_typeOfProductDal.CbbTypeOfProductGetAll(state), Messages.TypeOfProductGetAll);
        }

        public IResult ChangeState(int id, bool state)
        {
            _typeOfProductDal.ChangeState(id, state);
            return new SuccessResult(Messages.TypeOfProductChangeState);
        }

        public IResult Delete(int id)
        {
            _typeOfProductDal.Delete(id);
            return new SuccessResult(Messages.TypeOfProductDeleted);
        }

        public IDataResult<List<TypeOfProduct>> GetAll(int? id)
        {
            return new SuccessDataResult<List<TypeOfProduct>>(_typeOfProductDal.GetAll(id), Messages.TypeOfProductGetAll);
        }

        public IDataResult<TypeOfProduct> GetById(int id)
        {
            return new SuccessDataResult<TypeOfProduct>(_typeOfProductDal.GetById(id), Messages.TypeOfProductGetById);
        }

        public IResult Update(TypeOfProduct entity)
        {
            _typeOfProductDal.Update(entity);
            return new SuccessResult(Messages.TypeOfProductUpdated);
        }
    }
}
