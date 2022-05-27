using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstitutionManager : IInstitutionService
    {
        IInstitutionDal _institutionDal;
        public InstitutionManager(IInstitutionDal institutionDal)
        {
                _institutionDal = institutionDal;
        }
        public IResult Add(Institution entity)
        {
            _institutionDal.Add(entity);
            return new SuccessResult();
        }

        public IResult ChangeState(int id, bool state)
        {
            _institutionDal.ChangeState(id, state);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _institutionDal.Delete(id);
            return new SuccessResult();
        }

        public IDataResult<List<Institution>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Institution>>(_institutionDal.GetAll(id));
        }

        public IDataResult<Institution> GetById(int id)
        {
            return new SuccessDataResult<Institution>(_institutionDal.GetById(id));
        }

        public IResult Update(Institution entity)
        {
            _institutionDal.Update(entity);
            return new SuccessResult();
        }
    }
}
