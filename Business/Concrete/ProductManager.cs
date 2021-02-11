using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _IProductDal;
        public ProductManager(IProductDal productDal)
        {
            _IProductDal = productDal;
        }

        public IResult Add(Product product)
        {
            //Business codes
            if (product.ProductName.Length < 2)
            { 
                //magişc strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _IProductDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş Kodkları
            // Yetkisi var mı?
            return _IProductDal.GetAll();
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return DataResult(_IProductDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new DataResult(_IProductDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return _IProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public IDataResult<List<Product>> GetProductDetailsDtos()
        {
            return _IProductDal.GetProductDetails();
        }
    }
}
