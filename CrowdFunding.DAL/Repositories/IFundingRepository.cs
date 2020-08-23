using CrowdFunding.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    public interface IFundingRepository<TId, TEntity> : IBaseRepository<TId, TEntity>
    {
        IEnumerable<Funding> GetByProject(int projectId);
    }
}
