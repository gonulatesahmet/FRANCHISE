using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISessionDal : IEntityRepository<Session> 
    {
        Session SessionControl(int tableId, bool state);
        int SessionAdd(Session entity);
        void SessionEnd(Session entity);
        void MoveTheTable(int sessionId, int tableId);
    }
}
