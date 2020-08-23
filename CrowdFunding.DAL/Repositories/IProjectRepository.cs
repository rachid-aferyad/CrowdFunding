using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Views.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    public interface IProjectRepository<TId, TEntity> : IBaseRepository<TId, TEntity>
    {
        IEnumerable<VProjectListing> GetAllListing();
        VProjectDetails GetProjectDetailsById(int id);
        bool Update(Project project, BankAccount bankAccount, IEnumerable<int> categories, IEnumerable<Level> levels);
        int Insert(Project project, BankAccount bankAccount, IEnumerable<int> categories, IEnumerable<Level> levels);
    }
}
