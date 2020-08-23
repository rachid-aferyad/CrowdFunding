using CrowdFunding.DAL.Mappers;
using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Views.Projects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO;

namespace CrowdFunding.DAL.Repositories.Implementations
{
    public class ProjectRepository : BaseRepository, IProjectRepository<int, Project>
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteProject");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Project> GetAll()
        {
            Command command = new Command("CSP_GetAllProjects");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Project>());
        }

        public IEnumerable<VProjectListing> GetAllListing()
        {
            Command command = new Command("CSP_GetAllProjects");
            IEnumerable<VProjectListing> projects = _connection.ExecuteReader(command, reader => reader.MapTo<VProjectListing>());
            return projects;
        }

        public Project GetById(int id)
        {
            Command command = new Command("CSP_GetProjectById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Project>()).SingleOrDefault();
        }

        public VProjectDetails GetProjectDetailsById(int id)
        {
            Command command = new Command("CSP_GetProjectById");
            command.AddParameter("Id", id);
            VProjectDetails project = _connection.ExecuteReader(command, reader => reader.MapTo<VProjectDetails>()).SingleOrDefault();
            return project;
        }

        public Project GetByCategory(int categoryId)
        {
            Command command = new Command("CSP_GetProjectByCategory");
            command.AddParameter("CategoryId", categoryId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Project>()).SingleOrDefault();
        }

        public int Insert(Project project, BankAccount bankAccount, IEnumerable<int> categories, IEnumerable<Level> levels)
        {
            if(bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if(categories is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            DataTable categoriesDataTable = new DataTable();
            categoriesDataTable.Columns.Add("CategoryId", typeof(int));

            foreach(int categoryId in categories)
            {
                categoriesDataTable.Rows.Add(categoryId);
            }

            DataTable levelsDataTable = new DataTable();
            levelsDataTable.Columns.Add("Id", typeof(int));
            levelsDataTable.Columns.Add("Title", typeof(string));
            levelsDataTable.Columns.Add("Amount", typeof(string));
            levelsDataTable.Columns.Add("Award", typeof(string));
            
                
            Command command = new Command("CSP_AddProject");

            if(!(levels is null))
            {
                foreach (Level level in levels)
                {
                    levelsDataTable.Rows.Add(level.Id, level.Title, level.Amount, level.Award);
                }
            }

            command.AddParameter("Title", project.Title);
            command.AddParameter("Description", (object)project.Description ?? DBNull.Value);
            command.AddParameter("VideoLink", (object)project.VideoLink ?? DBNull.Value);
            command.AddParameter("LevelType", project.LevelType?? "FIXED");
            command.AddParameter("FundingCeiling", project.FundingCeiling);
            command.AddParameter("CreatorId", 1); // project.CreatorId);

            command.AddParameter("AccountNumber", bankAccount.AccountNumber);
            command.AddParameter("Country", bankAccount.Country);

            command.AddParameter("Categories", categoriesDataTable);
            command.AddParameter("Levels", (object)levelsDataTable ?? DBNull.Value);

            return (int)_connection.ExecuteNonQuery(command);
        }

        public bool Update(Project project, BankAccount bankAccount, IEnumerable<int> categories, IEnumerable<Level> levels)
        {

            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            if (categories is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            DataTable categoriesDataTable = new DataTable();
            categoriesDataTable.Columns.Add("CategoryId", typeof(int));

            foreach (int categoryId in categories)
            {
                categoriesDataTable.Rows.Add(categoryId);
            }

            DataTable levelsDataTable = new DataTable();
            levelsDataTable.Columns.Add("LevelId", typeof(int));
            levelsDataTable.Columns.Add("Title", typeof(string));
            levelsDataTable.Columns.Add("Amount", typeof(decimal));
            levelsDataTable.Columns.Add("Award", typeof(string));

            if (!(levels is null))
            {
                foreach (Level level in levels)
                {
                    levelsDataTable.Rows.Add(level.Id, level.Title, level.Amount, level.Award);
                }
            }

            Command command = new Command("CSP_UpdateProject");
            command.AddParameter("Id", project.Id);
            command.AddParameter("Title", project.Title);
            command.AddParameter("Description", project.Description);
            command.AddParameter("VideoLink", project.VideoLink);
            command.AddParameter("LevelType", project.LevelType ?? "FIXED");
            command.AddParameter("FundingCeiling", project.FundingCeiling);
            command.AddParameter("CreatorId", project.CreatorId);

            command.AddParameter("BankAccountId", bankAccount.Id);
            command.AddParameter("AccountNumber", bankAccount.AccountNumber);
            command.AddParameter("Country", bankAccount.Country);

            command.AddParameter("Categories", categoriesDataTable);
            command.AddParameter("Levels", levelsDataTable);

            return _connection.ExecuteNonQuery(command) > 0;
        }

        public int Insert(Project entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
