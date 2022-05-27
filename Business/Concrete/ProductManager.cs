using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult ChangeState(int id, bool state)
        {
            _productDal.ChangeState(id, state);
            return new SuccessResult(Messages.ProductChangeState);
        }

        public IResult Delete(int id)
        {
            _productDal.Delete(id);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(id),Messages.ProductGetAll);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.GetById(id), Messages.ProductGetById);
        }
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<ProductDto>> ProductDtoGetAll()
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.ProductDtoGetAll());
        }

        public IDataResult<List<Product>> ProductGetByCategory(int categoryId, bool state)
        {
            return new SuccessDataResult<List<Product>>(_productDal.ProductGetByCategory(categoryId, state), Messages.ProductGetAll);
        }

        public IDataResult<List<CbbProduct>> CbbProductGetNotAvailableInBranchProduct(int branchId, bool state)
        {
            return new SuccessDataResult<List<CbbProduct>>(_productDal.CbbProductGetNotAvailableInBranchProduct(branchId, state), Messages.ProductGetAll);
        }
    }
}
