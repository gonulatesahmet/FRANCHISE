using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SessionManager : ISessionService
    {
        ISessionDal _sessionDal;
        public SessionManager(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }
        public IResult Add(Session entity)
        {
            throw new System.NotImplementedException();
        }

        public IResult ChangeState(int id, bool state)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(int id)
        {
            _sessionDal.Delete(id);
            return new SuccessResult("Session Basariyla Silindi.");
        }

        public IDataResult<List<Session>> GetAll(int? id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Session> GetById(int id)
        {
            return new SuccessDataResult<Session>(_sessionDal.GetById(id));
        }

        public IResult Update(Session entity)
        {
            throw new System.NotImplementedException();
        }
        public IDataResult<Session> SessionControl(int tableId, bool state)
        {
            var control = _sessionDal.SessionControl(tableId, state);
            if(control == null)
            {
                return new ErrorDataResult<Session>("Session Yok");
            }
            else
            {
                return new SuccessDataResult<Session>(control);
            }
            

        }

        public IDataResult<int> SessionAdd(Session entity)
        {
            return new SuccessDataResult<int>(_sessionDal.SessionAdd(entity));
        }

        public IResult SessionEnd(Session entity)
        {
            _sessionDal.SessionEnd(entity);
            return new SuccessResult(Messages.SessionEnd);
        }

        public IResult MoveTheTable(int sessionId, int tableId)
        {
            _sessionDal.MoveTheTable(sessionId, tableId);
            return new SuccessResult("Masa Basariyla Degisti");
        }
    }
}
