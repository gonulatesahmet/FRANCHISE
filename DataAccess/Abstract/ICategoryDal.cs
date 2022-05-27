using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        List<CbbCategory> CbbCategoryGetAll(bool state);
    }
}
