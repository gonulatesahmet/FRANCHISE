using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDiscountService : IEntityRepositoryBusiness<Discount> 
    {
        IDataResult<List<CbbDiscount>> CbbDiscountGetAll(bool state);
        IDataResult<List<DiscountDto>> DiscountDtoGetAll(int? id);
        IDataResult<List<CbbDiscount>> DiscountGetNotAvailebleInBranchDiscount(int branchId, bool state);
    }
}
