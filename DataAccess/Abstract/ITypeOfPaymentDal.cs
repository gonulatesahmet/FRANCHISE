using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ITypeOfPaymentDal :IEntityRepository<TypeOfPayment> 
    {
        List<CbbTypeOfPayment> CbbTypeOfPaymentGetAll(bool state);
    }
}
