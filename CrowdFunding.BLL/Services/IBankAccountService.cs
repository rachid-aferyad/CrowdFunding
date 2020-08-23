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

namespace CrowdFunding.BLL.Services
{
    public interface IBankAccountService<TId, TEntity> : IBaseService<TId, TEntity>
    {
       TEntity GetByProject(int projectId);
    }
}
