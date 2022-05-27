using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchDiscountContentService : IEntityRepositoryBusiness<BranchDiscountContent>
    {
        IDataResult<List<BranchDiscountContentDto>> BranchDiscountContentDtoGetByBranch(int branchId);
        IDataResult<List<CbbBranchDiscountContent>> CbbBranchDiscountContentGetByBranch(int branchId, bool state);
        IDataResult<List<CbbBranchDiscountContent>> CbbBranchDiscountContentGetByBranchDiscount(int branchDiscountId, bool state);
    }
}
