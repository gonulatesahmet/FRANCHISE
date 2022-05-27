using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchDiscountManager : IBranchDiscountService
    {
        IBranchDiscountDal _branchDiscountDal;
        public BranchDiscountManager(IBranchDiscountDal branchDiscountDal)
        {
            _branchDiscountDal = branchDiscountDal;
        }
        public IResult Add(BranchDiscount entity)
        {
            IResult control = BusinessRules.Run(BranchDiscountEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountDal.Add(entity);
                return new SuccessResult(Messages.DiscountAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(BranchDiscountIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountDal.ChangeState(id, state);
                return new SuccessResult(Messages.DiscountChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(BranchDiscountIdControl(id));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountDal.Delete(id);
                return new SuccessResult(Messages.DiscountDeleted);
            }
        }

        public IDataResult<List<BranchDiscount>> GetAll(int? id)
        {
            return new SuccessDataResult<List<BranchDiscount>>(_branchDiscountDal.GetAll(id), Messages.DiscountGetAll);
        }

        public IDataResult<BranchDiscount> GetById(int id)
        {
            IResult control = BusinessRules.Run(BranchDiscountIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<BranchDiscount>(control.Message);
            }
            else
            {
                return new SuccessDataResult<BranchDiscount>(_branchDiscountDal.GetById(id), Messages.DiscountGetById);
            }
        }

        public IResult Update(BranchDiscount entity)
        {
            IResult control = BusinessRules.Run(BranchDiscountEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountDal.Update(entity);
                return new SuccessResult(Messages.DiscountUpdated);
            }
        }


        public IDataResult<List<BranchDiscountDto>> BranchDiscountDtoGetByBranch(int branchId)
        {
            IResult control = BusinessRules.Run(BranchDiscountIdControl(branchId));
            if(control != null)
            {
                return new ErrorDataResult<List<BranchDiscountDto>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<BranchDiscountDto>>(_branchDiscountDal.BranchDiscountDtoGetByBranch(branchId), Messages.BranchDiscountContentGetAll);
            }
        }

        public IDataResult<List<CbbBranchDiscount>> CbbBranchDiscountGetByBranch(int branchId, bool state)
        {
            IResult control = BusinessRules.Run(BranchDiscountIdControl(branchId));
            if(control != null)
            {
                return new ErrorDataResult<List<CbbBranchDiscount>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<CbbBranchDiscount>>(_branchDiscountDal.CbbBranchDiscountGetByBranch(branchId, state), Messages.BranchDiscountContentGetAll);
            }
        }



        //Rules
        private IResult BranchDiscountEntityControl(BranchDiscount entity)
        {
            if (entity.TypeOfDiscountId == 0) return new ErrorResult(Messages.TypeOfDiscountCannotBeEmpty);
            if (entity.DiscountId == 0) return new ErrorResult(Messages.DiscountCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchDiscountAmount.ToString())) return new ErrorResult(Messages.AmountCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult BranchDiscountIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
    }
}
