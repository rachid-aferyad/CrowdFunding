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

namespace CrowdFunding.BLL.Services.Implementations
{
    public class LevelService : ILevelService<int, LevelBO>
    {
        private ILevelRepository<int, Level> LevelRepository;
        public LevelService()
        {
            LevelRepository = new LevelRepository();
        }

        public bool Delete(int id)
        {
            return LevelRepository.Delete(id);
        }

        public IEnumerable<LevelBO> GetAll()
        {
            return LevelRepository.GetAll().Select(l => l.MapTo<LevelBO>());
        }

        public LevelBO GetById(int id)
        {
            return LevelRepository.GetById(id).MapTo<LevelBO>();
        }

        public IEnumerable<LevelBO> GetByProject(int projectId)
        {
            return LevelRepository.GetByProject(projectId).Select(l => l.MapTo<LevelBO>());
        }

        public int Save(LevelBO entity)
        {
            return LevelRepository.Insert(entity.MapTo<Level>());
        }

        public bool Update(int id, LevelBO entity)
        {
            Level level = entity.MapTo<Level>();
            level.Id = id;
            return LevelRepository.Update(level);
        }
    }
}
