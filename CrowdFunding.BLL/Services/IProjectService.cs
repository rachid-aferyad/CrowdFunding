using CrowdFunding.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public interface IProjectService<TId, TEntity> : IBaseService<TId, TEntity>
    {
        TId AddProject(ProjectBO project, BankAccountBO bankAccount, IEnumerable<LevelBO> levels, IEnumerable<int> categoriesId);

        int Save(ProjectBO project, BankAccountBO bankAccount, IEnumerable<int> categories, IEnumerable<LevelBO> levels);
        bool Update(int id, ProjectBO project, BankAccountBO bankAccount, IEnumerable<int> categories, IEnumerable<LevelBO> levels);
    }
}
