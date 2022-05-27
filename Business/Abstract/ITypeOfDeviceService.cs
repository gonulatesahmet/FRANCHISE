using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITypeOfDeviceService :IEntityRepositoryBusiness<TypeOfDevice>
    {
        IDataResult<List<CbbTypeOfDevice>> CbbTypeOfDeviceGetAll(bool TypeOfDeviceState);
    }
}
