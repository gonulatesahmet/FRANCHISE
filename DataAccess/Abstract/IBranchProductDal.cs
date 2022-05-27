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
    public interface IBranchProductDal : IEntityRepository<BranchProduct>
    {
        List<BranchProductDto> BranchProductDtoGetByBranch(int branchId, bool state);
        List<BranchProductDto> BranchProductDtoGetByCategory(int branchId, int categoryId, bool state);
        List<CbbBranchProduct> CbbBranchProductGetByBranch(int branchId, bool state);
    }
}
