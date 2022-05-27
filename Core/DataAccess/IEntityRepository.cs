using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(int? id);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void ChangeState(int id, bool state);
    }
}
