using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        IDiscountDal _discountDal;
        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }
        public IResult Add(Discount entity)
        {
            IResult control = BusinessRules.Run(DiscountEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _discountDal.Add(entity);
                return new SuccessResult(Messages.DiscountAdded);
            }
        }

        
        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(DiscountIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _discountDal.ChangeState(id, state);
                return new SuccessResult(Messages.DiscountChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(DiscountIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _discountDal.Delete(id);
                return new SuccessResult(Messages.DiscountDeleted);
            }
        }

        public IDataResult<List<Discount>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Discount>>(_discountDal.GetAll(id),Messages.DiscountGetAll);
        }

        public IDataResult<Discount> GetById(int id)
        {
            IResult control = BusinessRules.Run(DiscountIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<Discount>(control.Message);
            }
            else
            {
                return new SuccessDataResult<Discount>(_discountDal.GetById(id), Messages.DiscountGetById);
            }
        }

        public IResult Update(Discount entity)
        {
            IResult control = BusinessRules.Run(DiscountEntityControl(entity));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _discountDal.Update(entity);
                return new SuccessResult(Messages.DiscountUpdated);
            }
        }


        public IDataResult<List<CbbDiscount>> CbbDiscountGetAll(bool state)
        {
            return new SuccessDataResult<List<CbbDiscount>>(_discountDal.CbbDiscountGetAll(state), Messages.DiscountGetAll);
        }

        public IDataResult<List<CbbDiscount>> DiscountGetNotAvailebleInBranchDiscount(int branchId, bool state)
        {
            return new SuccessDataResult<List<CbbDiscount>>(_discountDal.DiscountGetNotAvailebleInBranchDiscount(branchId, state), Messages.DiscountGetAll);
        }

        public IDataResult<List<DiscountDto>> DiscountDtoGetAll(int? id)
        {
            return new SuccessDataResult<List<DiscountDto>>(_discountDal.DiscountDtoGetAll(id), Messages.DiscountGetAll);
        }



        //Rules
        private IResult DiscountEntityControl(Discount entity)
        {
            if (string.IsNullOrEmpty(entity.DiscountName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.DiscountCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.DiscountDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            if (entity.DiscountAmount == null) return new ErrorResult(Messages.AmountCannotBeEmpty);
            if (entity.TypeOfDiscountId == 1) return new ErrorResult(Messages.TypeOfDiscountCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult DiscountIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
    }
}
