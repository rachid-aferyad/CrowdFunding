using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Repositories
{
    public interface IBaseRepository<TId, TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TId id);
        TId Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TId id);
    }
}
