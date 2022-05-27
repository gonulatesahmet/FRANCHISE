using Core.Utilites.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IEntityRepositoryBusiness<T>
    {
        IDataResult<List<T>> GetAll(int? id);
        IDataResult<T> GetById(int id);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(int id);
        IResult ChangeState(int id, bool state);
    }
}
