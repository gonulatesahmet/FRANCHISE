using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService : IEntityRepositoryBusiness<Category> 
    {
        IDataResult<List<CbbCategory>> CbbCategoryGetAll(bool categoryState);
    }
}
