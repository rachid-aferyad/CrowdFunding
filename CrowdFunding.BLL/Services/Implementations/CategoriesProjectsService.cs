using CrowdFunding.BLL.Mappers;
using CrowdFunding.BLL.Models;
using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Repositories;
using CrowdFunding.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services.Implementations
{
    public class CategoriesProjectsService : ICategoriesProjectsService<int, CategoriesProjectsBO>
    {
        private ICategoriesProjectsRepository<int, CategoriesProjects> CategoriesProjectsRepository;
        public CategoriesProjectsService()
        {
            CategoriesProjectsRepository = new CategoriesProjectsRepository();
        }

        public bool Delete(int id)
        {
            return CategoriesProjectsRepository.Delete(id);
        }

        public IEnumerable<CategoriesProjectsBO> GetAll()
        {
            return CategoriesProjectsRepository.GetAll().Select(cp => cp.MapTo<CategoriesProjectsBO>());
        }

        public IEnumerable<CategoriesProjectsBO> GetByCategory(int categoryId)
        {
            return CategoriesProjectsRepository.GetByCategory(categoryId).Select(cp => cp.MapTo<CategoriesProjectsBO>());
        }

        public CategoriesProjectsBO GetById(int id)
        {
            return CategoriesProjectsRepository.GetById(id).MapTo<CategoriesProjectsBO>();
        }

        public CategoriesProjectsBO GetByProject(int projectId)
        {
            return CategoriesProjectsRepository.GetByProject(projectId).MapTo<CategoriesProjectsBO>();
        }

        public int Save(CategoriesProjectsBO entity)
        {
            return CategoriesProjectsRepository.Insert(entity.MapTo<CategoriesProjects>());
        }

        public bool Update(int id, CategoriesProjectsBO entity)
        {
            CategoriesProjects categoriesProjects = entity.MapTo<CategoriesProjects>();
            //categoriesProjects.Id = id;
            return CategoriesProjectsRepository.Update(categoriesProjects);
        }

        IEnumerable<CategoriesProjectsBO> ICategoriesProjectsService<int, CategoriesProjectsBO>.GetByProject(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
