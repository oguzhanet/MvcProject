using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcProject.Entities.Concrete;

namespace MvcProject.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> StatusIsTrue();
        List<Category> StatusIsFalse();
        Category GetById(int id);
        Category GetByName(string name);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
