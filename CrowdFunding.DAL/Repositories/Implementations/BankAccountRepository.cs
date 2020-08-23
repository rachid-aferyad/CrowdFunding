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
    public class BankAccountRepository : BaseRepository, IBankAccountRepository<int, BankAccount>
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_Delete");
            command.AddParameter("table", "BankAccount");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<BankAccount> GetAll()
        {
            Command command = new Command("CSP_GetAll");
            command.AddParameter("table", "BankAccount");
            return _connection.ExecuteReader(command, reader => reader.MapTo<BankAccount>());
        }

        public BankAccount GetById(int id)
        {
            Command command = new Command("CSP_GetById");
            command.AddParameter("table", "BankAccount");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<BankAccount>()).SingleOrDefault();
        }

        public BankAccount GetByProject(int projectId)
        {
            Command command = new Command("CSP_GetByProject");
            command.AddParameter("table", "BankAccount");
            command.AddParameter("ProjectId", projectId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<BankAccount>()).SingleOrDefault();
        }

        public int Insert(BankAccount entity)
        {
            Command command = new Command("CSP_AddBankAccount");
            command.AddParameter("AccountNumber", entity.AccountNumber);
            command.AddParameter("Country", entity.Country);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(BankAccount entity)
        {
            Command command = new Command("CSP_UpdateBankAccount");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("AccountNumber", entity.AccountNumber);
            command.AddParameter("Country", entity.Country);
            return _connection.ExecuteNonQuery(command) > 0;

        }
    }
}
