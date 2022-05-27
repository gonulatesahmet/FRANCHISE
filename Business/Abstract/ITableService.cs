using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITableService : IEntityRepositoryBusiness<Table> 
    {
        IDataResult<List<TableDto>> TableDtoGetByArea(int AreaId);
        IDataResult<List<CbbTable>> CbbTableGetByArea(int areaId, bool state);
        IResult TableChangeDisplay(int tableId, bool display);
        IDataResult<List<Table>> TableGetByArea(int areaId, bool state);
    }
}
