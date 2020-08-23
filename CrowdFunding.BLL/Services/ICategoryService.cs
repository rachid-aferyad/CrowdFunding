using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public interface ICategoryService<TId, TEntity> : IBaseService<TId, TEntity>
    {
        IEnumerable<TEntity> GetByProject(int projectId);
    }
}
