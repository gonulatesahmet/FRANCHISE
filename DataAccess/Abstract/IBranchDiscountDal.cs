using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBranchDiscountDal : IEntityRepository<BranchDiscount>
    {
        List<BranchDiscountDto> BranchDiscountDtoGetByBranch(int branchId);
        List<CbbBranchDiscount> CbbBranchDiscountGetByBranch(int branchId, bool state);
    }
}
