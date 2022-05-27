using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ITableDal :IEntityRepository <Table>
    {
        List<TableDto> TableDtoGetByArea(int AreaId);
        List<CbbTable> CbbTableGetByArea(int areaId, bool state);
        void TableChangeDisplay(int id, bool display);
        List<Table> TableGetByArea(int id, bool state);
    }
}
