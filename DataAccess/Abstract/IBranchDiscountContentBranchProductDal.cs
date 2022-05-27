using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBranchDiscountContentBranchProductDal : IEntityRepository<BranchDiscountContentBranchProduct>
    {
        List<BranchDiscountContentBranchProductDto> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContent);
        List<BranchDiscountContentBranchProductDto> BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(int branchDiscountContentId, bool state);
        List<BranchDiscountContentBranchProduct> BranchDiscountContentBranchProductGetByBranchDiscountContent(int branchDiscountContentId, bool state);
    }
}
