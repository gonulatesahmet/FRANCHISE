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
    public class BranchProductManager : IBranchProductService
    {
        IBranchProductDal _branchProductDal;
        public BranchProductManager(IBranchProductDal branchProductDal)
        {
            _branchProductDal = branchProductDal;
        }
        public IResult Add(BranchProduct entity)
        {
            IResult control = BusinessRules.Run(BranchProductEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchProductDal.Add(entity);
                return new SuccessResult(Messages.BranchProductAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(BranchProductIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchProductDal.ChangeState(id, state);
                return new SuccessResult(Messages.BranchProductChangeState);
            }
        }

        public IResult Delete(int id)
        {
            _branchProductDal.Delete(id);
            return new SuccessResult(Messages.BranchProductDeleted);
        }

        public IDataResult<List<BranchProduct>> GetAll(int? id)
        {
            return new SuccessDataResult<List<BranchProduct>>(_branchProductDal.GetAll(id), Messages.BranchProductGetAll);
        }

        public IDataResult<BranchProduct> GetById(int id)
        {
            IResult control = BusinessRules.Run(BranchProductIdControl(id));
            if(control != null)
            {
                return new ErrorDataResult<BranchProduct>(control.Message);
            }
            else
            {
                return new SuccessDataResult<BranchProduct>(_branchProductDal.GetById(id), Messages.BranchProductGetById);
            }
        }

        public IResult Update(BranchProduct entity)
        {
            IResult control = BusinessRules.Run(BranchProductEntityControl(entity));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _branchProductDal.Update(entity);
                return new SuccessResult(Messages.BranchProductUpdated);
            }
        }


        public IDataResult<List<BranchProductDto>> BranchProductDtoGetByBranch(int branchId, bool state)
        {
            IResult control = BusinessRules.Run(BranchProductIdControl(branchId));
            if (control != null)
            {
                return new ErrorDataResult<List<BranchProductDto>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<BranchProductDto>>(_branchProductDal.BranchProductDtoGetByBranch(branchId, state), Messages.BranchProductGetAll);
            }
        }

        public IDataResult<List<BranchProductDto>> BranchProductDtoGetByCategory(int branchId, int categoryId, bool state)
        {
            IResult control = BusinessRules.Run(BranchProductIdControl(branchId), BranchProductIdControl(categoryId));
            if (control != null)
            {
                return new ErrorDataResult<List<BranchProductDto>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<BranchProductDto>>(_branchProductDal.BranchProductDtoGetByCategory(branchId, categoryId, state));
            }
        }

        public IDataResult<List<CbbBranchProduct>> CbbBranchProductGetByBranch(int branchId, bool state)
        {
            IResult control = BusinessRules.Run(BranchProductIdControl(branchId));
            if(control != null)
            {
                return new ErrorDataResult<List<CbbBranchProduct>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<CbbBranchProduct>>(_branchProductDal.CbbBranchProductGetByBranch(branchId, state));
            }
        }



        //Rules
        private IResult BranchProductEntityControl(BranchProduct entity)
        {
            if (entity.ProductId == 0) return new ErrorResult(Messages.ProductCannotBeEmpty);
            if (entity.BranchProductPrice.ToString() == null) return new ErrorResult(Messages.AmountCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult BranchProductIdControl(int id)
        {
            if (id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
    }
}
