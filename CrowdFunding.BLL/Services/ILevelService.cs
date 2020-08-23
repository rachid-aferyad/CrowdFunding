using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public interface ILevelService<TId, TEntity> : IBaseService<TId, TEntity>
    {
        IEnumerable<TEntity> GetByProject(TId projectId);
    }
}
