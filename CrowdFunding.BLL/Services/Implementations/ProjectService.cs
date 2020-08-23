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
    public class ProjectService : IProjectService<int, ProjectBO>
    {
        private IProjectRepository<int, Project> _projectRepository;
        private ILevelService<int, LevelBO> LevelService;
        private IBankAccountService<int, BankAccountBO> _bankAccountService;
        private ICategoriesProjectsService<int, CategoriesProjectsBO> CategoriesProjectsService;
        public ProjectService()
        {
            _projectRepository = new ProjectRepository();
            LevelService = new LevelService();
            _bankAccountService = new BankAccountService();
            CategoriesProjectsService = new CategoriesProjectsService();
        }

        public int AddProject(ProjectBO project, BankAccountBO bankAccount, IEnumerable<LevelBO> levels, IEnumerable<int> categoriesIds)
        {
            bankAccount.Id = _bankAccountService.Save(bankAccount);
            project.BankAccount = bankAccount;

            project.Id = Save(project);

            categoriesIds.ToList().ForEach(categoryId =>
            {
                CategoriesProjectsService.Save(new CategoriesProjectsBO(project.Id, categoryId));
            });

            levels.ToList().ForEach(level =>
            {
                level.ProjectId = project.Id;
                LevelService.Save(level);
            });

            return project.Id;
        }

        public bool Delete(int id)
        {
            return _projectRepository.Delete(id);
        }

        public IEnumerable<ProjectBO> GetAll()
        {
            IEnumerable<ProjectBO> projects = _projectRepository.GetAllListing().Select(u => u.MapTo<ProjectBO>());
            return projects;
        }

        public ProjectBO GetById(int id)
        {
            return _projectRepository.GetProjectDetailsById(id).MapTo<ProjectBO>();
        }
 
        public int Save(ProjectBO entity)
        {
            _bankAccountService.Save(entity.BankAccount);
            return _projectRepository.Insert(entity.ToDAL());
        }

        public bool Update(int id, ProjectBO entity)
        {
            Project dalProject = entity.MapTo<Project>();
            dalProject.Id = id;
            return _projectRepository.Update(dalProject);
        }

        public int Save(ProjectBO project, BankAccountBO bankAccount, IEnumerable<int> categories, IEnumerable<LevelBO> levels)
        {
            return (int)_projectRepository.Insert(project.MapTo<Project>(), bankAccount.MapTo<BankAccount>(), categories, levels?.Select(l => l.MapTo<Level>()));
        }

        public bool Update(int id, ProjectBO project, BankAccountBO bankAccount, IEnumerable<int> categories, IEnumerable<LevelBO> levels)
        {
            Project dalProject = project.MapTo<Project>();
            dalProject.Id = id;
            return _projectRepository.Update(dalProject, bankAccount.MapTo<BankAccount>(), categories, levels.Select(l => l.MapTo<Level>()));
        }
    }
}
