using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public interface IBranchDiscountContentBranchProductService : IEntityRepositoryBusiness<BranchDiscountContentBranchProduct>
    {
        IDataResult<List<BranchDiscountContentBranchProductDto>> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContentBranchProductId);
        IDataResult<List<BranchDiscountContentBranchProductDto>> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContentBranchProductId, bool state);
        IDataResult<List<BranchDiscountContentBranchProduct>> BranchDiscountContentBranchProductGetByBranchDiscountContent(int branchDiscountContentId, bool state);
    }
}