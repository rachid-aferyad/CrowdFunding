using CrowdFunding.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Services
{
    public interface IFundingService<TId, TEntity> : IBaseService<TId, TEntity>
    {
        IEnumerable<FundingBO> GetByProject(int projectId);
    }
}
