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
    public interface IBranchDiscountService : IEntityRepositoryBusiness<BranchDiscount>
    {
        IDataResult<List<BranchDiscountDto>> BranchDiscountDtoGetByBranch(int branchId);
        IDataResult<List<CbbBranchDiscount>> CbbBranchDiscountGetByBranch(int branchId, bool state);
        
    }
}
