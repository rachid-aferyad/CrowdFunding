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
    public class LevelRepository : BaseRepository, ILevelRepository<int, Level>
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_Delete");
            command.AddParameter("Table", "Level");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Level> GetAll()
        {
            Command command = new Command("CSP_GetAll");
            command.AddParameter("Table", "Level");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Level>());
        }

        public Level GetById(int id)
        {
            Command command = new Command("CSP_GetById");
            command.AddParameter("Table", "Level");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Level>()).SingleOrDefault();
        }

        public IEnumerable<Level> GetByProject(int projectId)
        {
            Command command = new Command("CSP_GetByProject");
            command.AddParameter("Table", "Level");
            command.AddParameter("ProjectId", projectId);
            IEnumerable<Level> levels = _connection.ExecuteReader(command, reader => reader.MapTo<Level>());
            return levels;
        }

        public int Insert(Level entity)
        {
            Command command = new Command("CSPAddLevel");
            command.AddParameter("Title", entity.Title);
            command.AddParameter("Amount", entity.Amount);
            command.AddParameter("Award", entity.Award);
            command.AddParameter("ProjectId", entity.ProjectId);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Level entity)
        {
            Command command = new Command("CSP_UpdateLevel");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Title", entity.Title);
            command.AddParameter("Amount", entity.Amount);
            command.AddParameter("Award", entity.Award);
            return _connection.ExecuteNonQuery(command) > 0;

        }
    }
}
