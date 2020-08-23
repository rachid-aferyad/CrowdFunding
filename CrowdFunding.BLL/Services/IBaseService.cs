using System;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFunding.BLL.Services
{
    public interface IBaseService<TId, TEntity>
    {
        TId Save(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TId id);
        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
