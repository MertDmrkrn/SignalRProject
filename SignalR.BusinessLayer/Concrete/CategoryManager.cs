using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryService _categoryService;

        public CategoryManager(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void TAdd(Category entity)
        {
            _categoryService.TAdd(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryService.TDelete(entity);
        }

        public Category TGetByID(int id)
        {
            return _categoryService.TGetByID(id);   
        }

        public List<Category> TGetListAll()
        {
            return _categoryService.TGetListAll();
        }

        public void TUpdate(Category entity)
        {
            _categoryService.TUpdate(entity);
        }
    }
}
