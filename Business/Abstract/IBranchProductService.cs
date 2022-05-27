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
    public interface IBranchProductService : IEntityRepositoryBusiness<BranchProduct>
    {
        IDataResult<List<BranchProductDto>> BranchProductDtoGetByBranch(int branchId, bool state);
        IDataResult<List<BranchProductDto>> BranchProductDtoGetByCategory(int branchId, int categoryId, bool state);
        IDataResult<List<CbbBranchProduct>> CbbBranchProductGetByBranch(int branchId, bool state);
    }
}
