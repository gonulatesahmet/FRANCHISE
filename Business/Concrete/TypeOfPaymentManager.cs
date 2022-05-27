using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TypeOfPaymentManager : ITypeOfPaymentService
    {
        ITypeOfPaymentDal _typeOfPaymentDal;
        public TypeOfPaymentManager(ITypeOfPaymentDal typeOfPaymentDal)
        {
            _typeOfPaymentDal = typeOfPaymentDal;
        }
        public IResult Add(TypeOfPayment entity)
        {
            IResult control = BusinessRules.Run(TypeOfPaymentEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _typeOfPaymentDal.Add(entity);
                return new SuccessResult(Messages.TypeOfPaymentAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(TypeOfPaymentIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _typeOfPaymentDal.ChangeState(id, state);
                return new SuccessResult(Messages.TypeOfPaymentChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(TypeOfPaymentIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _typeOfPaymentDal.Delete(id);
                return new SuccessResult(Messages.TypeOfPaymentDeleted);
            }
        }

        public IDataResult<List<TypeOfPayment>> GetAll(int? id)
        {
            return new SuccessDataResult<List<TypeOfPayment>>(_typeOfPaymentDal.GetAll(id),Messages.TypeOfPaymentGetAll);
        }

        public IDataResult<TypeOfPayment> GetById(int id)
        {
            IResult control = BusinessRules.Run(TypeOfPaymentIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<TypeOfPayment>(control.Message);
            }
            else
            {
                return new SuccessDataResult<TypeOfPayment>(_typeOfPaymentDal.GetById(id), Messages.TypeOfPaymentGetById);
            }
        }

        public IResult Update(TypeOfPayment entity)
        {
            IResult control = BusinessRules.Run(TypeOfPaymentEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _typeOfPaymentDal.Update(entity);
                return new SuccessResult(Messages.TypeOfPaymentUpdated);
            }
        }

        public IDataResult<List<CbbTypeOfPayment>> CbbTypeOfPaymentGetAll(bool state)
        {
            return new SuccessDataResult<List<CbbTypeOfPayment>>(_typeOfPaymentDal.CbbTypeOfPaymentGetAll(state), Messages.TypeOfPaymentGetAll);
        }





        //Rules
        private IResult TypeOfPaymentEntityControl(TypeOfPayment entity)
        {
            if (string.IsNullOrEmpty(entity.TypeOfPaymentName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.TypeOfPaymentCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.TypeOfPaymentDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult TypeOfPaymentIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
    }
}
