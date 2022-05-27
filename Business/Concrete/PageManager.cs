using Business.Abstract;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PageManager : IPageService
    {
        IPageDal _pageDal;
        public PageManager(IPageDal pageDal)
        {
            _pageDal = pageDal;
        }
        public IResult Add(Page entity)
        {
            throw new System.NotImplementedException();
        }

        public IResult ChangeState(int id, bool state)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Page>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Page>>(_pageDal.GetAll(id));
        }

        public IDataResult<Page> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(Page entity)
        {
            _pageDal.Update(entity);
            return new SuccessResult("Sayfa Bilgileri Guncellendi.");
        }
    }
}
