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
    public interface IAreaService : IEntityRepositoryBusiness<Area>
    {
        IDataResult<List<CbbArea>> CbbAreaGetAll(int branchId, bool areaState);
        IDataResult<List<AreaDto>> AreaDtoGetByBranch(int branchId);
    }
}
