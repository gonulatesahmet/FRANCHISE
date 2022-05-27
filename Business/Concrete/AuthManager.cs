using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IAuthDal _authDal;
        public AuthManager(IAuthDal authDal)
        {
            _authDal = authDal;
        }
        public IResult Add(Auth entity)
        {
            _authDal.Add(entity);
            return new SuccessResult(Messages.AuthAdded);
        }

        public IResult ChangeState(int id, bool state)
        {
            _authDal.ChangeState(id, state);
            return new SuccessResult(Messages.AuthChangeState);
        }

        public IResult Delete(int id)
        {
            _authDal.Delete(id);
            return new SuccessResult(Messages.AuthDeleted);
        }

        public IDataResult<List<Auth>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Auth>>(_authDal.GetAll(id));
        }

        public IDataResult<Auth> GetById(int id)
        {
            return new SuccessDataResult<Auth>(_authDal.GetById(id));
        }

        public IResult Update(Auth entity)
        {
            _authDal.Update(entity);
            return new SuccessResult(Messages.AuthUpdated);
        }
        public IDataResult<List<CbbAuth>> CbbAuthGetAll(bool state)
        {
            return new SuccessDataResult<List<CbbAuth>>(_authDal.CbbAuthGetAll(state));
        }

    }
}
