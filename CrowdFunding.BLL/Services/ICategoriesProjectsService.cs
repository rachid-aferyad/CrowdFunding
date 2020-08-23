using CrowdFunding.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public interface ICategoriesProjectsService<TId, TEntity> : IBaseService<TId, TEntity>
    {
        IEnumerable<TEntity> GetByProject(int projectId);
        IEnumerable<TEntity> GetByCategory(int categoryId);
    }
}
