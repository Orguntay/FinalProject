using Business.Abstract;
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
