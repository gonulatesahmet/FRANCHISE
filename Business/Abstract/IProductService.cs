using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService : IEntityRepositoryBusiness<Product>
    {
        IDataResult<List<Product>> ProductGetByCategory(int categoryId, bool state);
        IDataResult<List<ProductDto>> ProductDtoGetAll();
        IDataResult<List<CbbProduct>> CbbProductGetNotAvailableInBranchProduct(int branchId, bool state);
    }
}
