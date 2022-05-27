using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAuthService : IEntityRepositoryBusiness<Auth>
    {
        IDataResult<List<CbbAuth>> CbbAuthGetAll(bool state);
    }
}
