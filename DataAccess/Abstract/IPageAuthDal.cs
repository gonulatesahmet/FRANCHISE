using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPageAuthDal : IEntityRepository<PageAuth>
    {
        List<PageAuth> PageAuthGetByAuth(int AuthId);
        List<PageAuthDto> PageAuthDtoGetByAuth(int AuthId);

    }
}
