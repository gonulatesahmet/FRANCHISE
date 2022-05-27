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
    public class BranchDiscountContentManager : IBranchDiscountContentService
    {
        IBranchDiscountContentDal _branchDiscountContentDal;
        public BranchDiscountContentManager(IBranchDiscountContentDal branchDiscountContentDal)
        {
            _branchDiscountContentDal = branchDiscountContentDal;
        }
        public IResult Add(BranchDiscountContent entity)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountContentDal.Add(entity);
                return new SuccessResult(Messages.BranchDiscountContentAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountContentDal.ChangeState(id, state);
                return new SuccessResult(Messages.BranchDiscountContentChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountContentDal.Delete(id);
                return new SuccessResult(Messages.BranchDiscountContentDeleted);
            }
        }

        public IDataResult<List<BranchDiscountContent>> GetAll(int? id)
        {
            return new SuccessDataResult<List<BranchDiscountContent>>(_branchDiscountContentDal.GetAll(id), Messages.BranchDiscountContentGetAll);
        }

        public IDataResult<BranchDiscountContent> GetById(int id)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<BranchDiscountContent>(control.Message);
            }
            else
            {
                return new SuccessDataResult<BranchDiscountContent>(_branchDiscountContentDal.GetById(id), Messages.BranchDiscountContentGetById);
            }
        }

        public IResult Update(BranchDiscountContent entity)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchDiscountContentDal.Update(entity);
                return new SuccessResult(Messages.BranchDiscountContentUpdated);
            }
        }



        public IDataResult<List<BranchDiscountContentDto>> BranchDiscountContentDtoGetByBranch(int branchId)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentIdControl(branchId));
            if (control != null)
            {
                return new ErrorDataResult<List<BranchDiscountContentDto>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<BranchDiscountContentDto>>(_branchDiscountContentDal.BranchDiscountContentDtoGetByBranch(branchId), Messages.BranchDiscountContentGetAll);
            }
        }

        public IDataResult<List<CbbBranchDiscountContent>> CbbBranchDiscountContentGetByBranch(int branchId, bool state)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentIdControl(branchId));
            if(control != null)
            {
                return new ErrorDataResult<List<CbbBranchDiscountContent>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<CbbBranchDiscountContent>>(_branchDiscountContentDal.CbbBranchDiscountContentGetByBranch(branchId, state), Messages.BranchDiscountContentGetAll);
            }
        }

        public IDataResult<List<CbbBranchDiscountContent>> CbbBranchDiscountContentGetByBranchDiscount(int branchDiscountId, bool state)
        {
            IResult control = BusinessRules.Run(BranchDiscountContentIdControl(branchDiscountId));
            if(control != null)
            {
                return new ErrorDataResult<List<CbbBranchDiscountContent>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<CbbBranchDiscountContent>>(_branchDiscountContentDal.CbbBranchDiscountContentGetByBranchDiscount(branchDiscountId, state), Messages.BranchDiscountContentGetAll);
            }
        }




        //Rules
        private IResult BranchDiscountContentEntityControl(BranchDiscountContent entity)
        {
            if (string.IsNullOrEmpty(entity.BranchDiscountContentName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchDiscountContentCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.BranchDiscountContentDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            if (entity.BranchDiscountId == 0) return new ErrorResult(Messages.DiscountCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult BranchDiscountContentIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }

    }
}
