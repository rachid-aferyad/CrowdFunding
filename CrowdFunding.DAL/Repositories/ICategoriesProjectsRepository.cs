using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    public interface ICategoriesProjectsRepository<TId, TEntity> : IBaseRepository<TId, TEntity>
    {
        IEnumerable<TEntity> GetByProject(int projectId);
        IEnumerable<TEntity> GetByCategory(int categoryId);
    }
}
