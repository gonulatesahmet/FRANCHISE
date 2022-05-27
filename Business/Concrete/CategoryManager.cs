using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category entity)
        {
            IResult control = BusinessRules.Run(CategoryEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _categoryDal.Add(entity);
                return new SuccessResult(Messages.CategoryAdded);
            }
        }
        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(CategoryIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _categoryDal.ChangeState(id, state);
                return new SuccessResult(Messages.CategoryChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(CategoryIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _categoryDal.Delete(id);
                return new SuccessResult(Messages.CategoryDeleted);
            }
        }

        public IDataResult<List<Category>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(id),Messages.CategoryGetAll);
        }

        public IDataResult<Category> GetById(int id)
        {
            IResult control = BusinessRules.Run(CategoryIdControl(id));
            if (control != null)
            {
                return new ErrorDataResult<Category>(control.Message);
            }
            return new SuccessDataResult<Category>(_categoryDal.GetById(id),Messages.CategoryGetById);
        }

        public IResult Update(Category entity)
        {
            IResult control = BusinessRules.Run(CategoryEntityControl(entity));
            if (control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _categoryDal.Update(entity);
                return new SuccessResult(Messages.CategoryUpdated);
            }
        }




        public IDataResult<List<CbbCategory>> CbbCategoryGetAll(bool categoryState)
        {
            return new SuccessDataResult<List<CbbCategory>>(_categoryDal.CbbCategoryGetAll(categoryState));
        }






        ///Rules
        private IResult CategoryEntityControl(Category entity)
        {
            if (string.IsNullOrEmpty(entity.CategoryName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if(string.IsNullOrEmpty(entity.CategoryCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if(string.IsNullOrEmpty(entity.CategoryDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult CategoryIdControl(int id)
        {
            if(id == 0)
            {
                return new ErrorResult(Messages.IdNotFound);
            }
            return new SuccessResult();
        }
    }
}
