using CrowdFunding.DAL.Mappers;
using CrowdFunding.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO;

namespace CrowdFunding.DAL.Repositories.Implementations
{
    public class FundingRepository : BaseRepository, IFundingRepository<int, Funding>
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteFunding");
            command.AddParameter("Id", id);
            //command.AddParameter("Table", "Funding");
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Funding> GetAll()
        {
            Command command = new Command("CSP_GetAllFundings");
            return _connection.ExecuteReader(command, (reader) => reader.MapTo<Funding>());
        }

        public Funding GetById(int id)
        {
            Command command = new Command("CSP_GetFundingById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, (reader) => reader.MapTo<Funding>()).SingleOrDefault();
        }

        public IEnumerable<Funding> GetByProject(int projectId)
        {
            Command command = new Command("CSP_GetByProject");
            command.AddParameter("Table", "Funding");
            command.AddParameter("ProjectId", projectId);
            IEnumerable<Funding> fundings = _connection.ExecuteReader(command, reader => reader.MapTo<Funding>());
            return fundings;
        }

        public int Insert(Funding entity)
        {
            Command command = new Command("CSP_AddFunding");
            command.AddParameter("ProjectId", entity.ProjectId);
            command.AddParameter("FunderId", 1); // entity.FunderId);
            command.AddParameter("Amount", entity.Amount);
            _connection.ExecuteScalar(command);
            return 1;
        }

        public bool Update(Funding entity)
        {
            Command command = new Command("CSP_UpdateFunding");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("ProjectId", entity.ProjectId);
            command.AddParameter("FunderId", entity.FunderId);
            command.AddParameter("Amount", entity.Amount);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
