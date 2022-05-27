using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IAuthDal : IEntityRepository<Auth> 
    {
        List<CbbAuth> CbbAuthGetAll(bool state);
    }
}
