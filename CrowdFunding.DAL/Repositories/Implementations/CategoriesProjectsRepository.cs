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
    public class CategoriesProjectsRepository : BaseRepository, ICategoriesProjectsRepository<int, CategoriesProjects>
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_Delete");
            command.AddParameter("Table", "CategoriesProjects");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<CategoriesProjects> GetAll()
        {
            Command command = new Command("CSP_GetAll");
            command.AddParameter("Table", "CategoriesProjects");
            return _connection.ExecuteReader(command, reader => reader.MapTo<CategoriesProjects>());
        }

        public CategoriesProjects GetById(int id)
        {
            Command command = new Command("CSP_GetById");
            command.AddParameter("Table", "CategoriesProjects");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<CategoriesProjects>()).SingleOrDefault();
        }

        public IEnumerable<CategoriesProjects> GetByProject(int projectId)
        {
            Command command = new Command("CSP_GetByProject");
            command.AddParameter("Table", "CategoriesProjects");
            command.AddParameter("ProjectId", projectId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<CategoriesProjects>());
        }

        public IEnumerable<CategoriesProjects> GetByCategory(int categoryId)
        {
            Command command = new Command("CSP_GetByCategory");
            command.AddParameter("Table", "CategoriesProjects");
            command.AddParameter("CategoryId", categoryId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<CategoriesProjects>());
        }

        public int Insert(CategoriesProjects entity)
        {
            Command command = new Command("CSP_AddCategoriesProjects");
            command.AddParameter("ProjectId", entity.ProjectId);
            command.AddParameter("CategoryId", entity.CategoryId);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(CategoriesProjects entity)
        {
            throw new NotImplementedException();
        }
    }
}
