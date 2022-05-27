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
    public interface IBranchDiscountContentDal : IEntityRepository<BranchDiscountContent>
    {
        List<BranchDiscountContentDto> BranchDiscountContentDtoGetByBranch(int branchId);
        List<CbbBranchDiscountContent> CbbBranchDiscountContentGetByBranch(int branchId, bool state);
        List<CbbBranchDiscountContent> CbbBranchDiscountContentGetByBranchDiscount(int branchDiscountId, bool state);
    }
}
