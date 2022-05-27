using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IDiscountDal : IEntityRepository<Discount>
    {
        List<CbbDiscount> CbbDiscountGetAll(bool state);
        List<DiscountDto> DiscountDtoGetAll(int? id);
        List<CbbDiscount> DiscountGetNotAvailebleInBranchDiscount(int branchId, bool state);
    }
}
