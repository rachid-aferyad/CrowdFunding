using CrowdFunding.BLL.Mappers;
using CrowdFunding.BLL.Models;
using CrowdFunding.BLL.Services;
using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Repositories;
using CrowdFunding.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Repositories.Implementations
{
    public class CategoryService : ICategoryService<int, CategoryBO>
    {
        private ICategoryRepository<int, Category> CategoryRepository;
        public CategoryService()
        {
            CategoryRepository = new CategoryRepository();
        }

        public bool Delete(int id)
        {
            return CategoryRepository.Delete(id);
        }

        public IEnumerable<CategoryBO> GetAll()
        {
            return CategoryRepository.GetAll().Select(c => c.MapTo<CategoryBO>());
        }

        public CategoryBO GetById(int id)
        {
            return CategoryRepository.GetById(id).MapTo<CategoryBO>();
        }

        public IEnumerable<CategoryBO> GetByProject(int projectId)
        {
            return CategoryRepository.GetByProject(projectId).Select(c => c.MapTo<CategoryBO>());
        }

        public int Save(CategoryBO entity)
        {
            return CategoryRepository.Insert(entity.MapTo<Category>());
        }

        public bool Update(int id, CategoryBO entity)
        {
            Category category = entity.MapTo<Category>();
            category.Id = id;
            return CategoryRepository.Update(category);
        }
    }
}
