using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZZG.Business.Abstract;
using ZZG.DataAccess.Abstract;
using ZZG.Entities;

namespace ZZG.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll().ToList();
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
