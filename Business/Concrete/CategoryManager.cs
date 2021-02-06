using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoyyDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoyyDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            // iş kodları
            return _categoyyDal.GetAll();
        }
        // select * from Categories where Category = 3
        public Category GetById(int categoryId)
        {
            return _categoyyDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
