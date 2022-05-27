using Core.Business;
using Core.Utilites.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISessionService  : IEntityRepositoryBusiness<Session> 
    {
        IDataResult<Session> SessionControl(int tableId, bool state);
        IDataResult<int> SessionAdd(Session entity);
        IResult SessionEnd(Session entity);
        IResult MoveTheTable(int sessionId, int tableId);
    }
}
