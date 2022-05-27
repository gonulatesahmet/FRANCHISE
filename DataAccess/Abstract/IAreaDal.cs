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
    public interface IAreaDal : IEntityRepository<Area>
    {
        List<CbbArea> CbbAreaGetAll(int branchId, bool areaState);
        List<AreaDto> AreaDtoGetByBranch(int branchId);
    }
}
