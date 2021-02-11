using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (product.ProductName.Length < 2 )
            {
                return ErrorResult("Ürün ismi en az 2 karakter olmalıdır");// yanlış
            }
            _IProductDal.Add(product);

            return new SuccessResult("Ürün eklendi");
        }

        public List<Product> GetAll()
        {
            // İş Kodkları
            // Yetkisi var mı?
            return _IProductDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _IProductDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _IProductDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _IProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetailsDtos()
        {
            return _IProductDal.GetProductDetails();
        }
    }
}
