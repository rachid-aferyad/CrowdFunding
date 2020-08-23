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
    public class FundingService : BaseService, IFundingService<int, FundingBO>
    {
        private IFundingRepository<int, Funding> FundingRepository;
        public FundingService()
        {
            FundingRepository = new FundingRepository();
        }

        public bool Delete(int id)
        {
            return FundingRepository.Delete(id);
        }

        public IEnumerable<FundingBO> GetAll()
        {
            return FundingRepository.GetAll().Select(l => l.MapTo<FundingBO>());
        }

        public FundingBO GetById(int id)
        {
            return FundingRepository.GetById(id).MapTo<FundingBO>();
        }

        public IEnumerable<FundingBO> GetByProject(int projectId)
        {
            return FundingRepository.GetByProject(projectId).Select(l => l.MapTo<FundingBO>());
        }

        public int Save(FundingBO entity)
        {
            return FundingRepository.Insert(entity.MapTo<Funding>());
        }

        public bool Update(int id, FundingBO entity)
        {
            Funding funding = entity.MapTo<Funding>();
            funding.Id = id;
            return FundingRepository.Update(funding);
        }
    }
}
