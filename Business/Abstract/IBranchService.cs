using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBranchService : IEntityRepositoryBusiness<Branch> 
    {
        IDataResult<List<CbbBranch>> CbbBranchGetAll(int InstitutionId,bool BranchState);
    }
}
