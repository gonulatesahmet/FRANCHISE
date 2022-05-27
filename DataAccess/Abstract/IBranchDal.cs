using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBranchDal : IEntityRepository<Branch>
    {
        List<CbbBranch> CbbBranchGetAll(int InstitutionId, bool BranchState);
    }
}
