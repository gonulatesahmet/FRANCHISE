using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITypeOfPaymentService : IEntityRepositoryBusiness<TypeOfPayment>
    {
        IDataResult<List<CbbTypeOfPayment>> CbbTypeOfPaymentGetAll(bool state);
    }
}
