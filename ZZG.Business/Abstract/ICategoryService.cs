using System;
using System.Collections.Generic;
using System.Text;
using ZZG.Entities;

namespace ZZG.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Create(Category entity);
        void Delete(Category entity);
        void Update(Category entity);
    }
}
