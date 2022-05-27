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
    public class BranchDiscountContentBranchProductManager : IBranchDiscountContentBranchProductService
    {
        IBranchDiscountContentBranchProductDal _branchDiscountContentBranchProductDal;
        public BranchDiscountContentBranchProductManager(IBranchDiscountContentBranchProductDal branchDiscountContentBranchProductDal)
        {
            _branchDiscountContentBranchProductDal = branchDiscountContentBranchProductDal;
        }
        public IResult Add(BranchDiscountContentBranchProduct entity)
        {
            _branchDiscountContentBranchProductDal.Add(entity);
            return new SuccessResult(Messages.DiscountAdded);
        }

        public IResult ChangeState(int id, bool state)
        {
            _branchDiscountContentBranchProductDal.ChangeState(id, state);
            return new SuccessResult(Messages.DiscountChangeState);
        }

        public IResult Delete(int id)
        {
            _branchDiscountContentBranchProductDal.Delete(id);
            return new SuccessResult(Messages.DiscountDeleted);
        }

        public IDataResult<List<BranchDiscountContentBranchProduct>> GetAll(int? id)
        {
            return new SuccessDataResult<List<BranchDiscountContentBranchProduct>>(_branchDiscountContentBranchProductDal.GetAll(id), Messages.DiscountGetAll);
        }

        public IDataResult<BranchDiscountContentBranchProduct> GetById(int id)
        {
            return new SuccessDataResult<BranchDiscountContentBranchProduct>(_branchDiscountContentBranchProductDal.GetById(id),Messages.DiscountGetById);
        }

        public IResult Update(BranchDiscountContentBranchProduct entity)
        {
            _branchDiscountContentBranchProductDal.Update(entity);
            return new SuccessResult(Messages.DiscountUpdated);
        }
        public IDataResult<List<BranchDiscountContentBranchProductDto>> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContentBranchProductId)
        {
            return new SuccessDataResult<List<BranchDiscountContentBranchProductDto>>(_branchDiscountContentBranchProductDal.BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(branchDiscountContentBranchProductId), Messages.DiscountGetAll);
        }

        public IDataResult<List<BranchDiscountContentBranchProduct>> BranchDiscountContentBranchProductGetByBranchDiscountContent(int branchDiscountContentId, bool state)
        {
            return new SuccessDataResult<List<BranchDiscountContentBranchProduct>>(_branchDiscountContentBranchProductDal.BranchDiscountContentBranchProductGetByBranchDiscountContent(branchDiscountContentId, state));
        }

        public IDataResult<List<BranchDiscountContentBranchProductDto>> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContentBranchProductId, bool state)
        {
            return new SuccessDataResult<List<BranchDiscountContentBranchProductDto>>(_branchDiscountContentBranchProductDal.BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(branchDiscountContentBranchProductId, state), Messages.DiscountGetAll);
        }
    }
}
