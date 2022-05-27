using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository <Product> 
    {
        List<ProductDto> ProductDtoGetAll();
        List<Product> ProductGetByCategory(int categoryId, bool state);
        List<CbbProduct> CbbProductGetNotAvailableInBranchProduct(int branchId, bool state);
    }
}
