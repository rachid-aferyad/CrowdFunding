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
    public class UserRepository : BaseRepository, IUserRepository<int, User>
    {
        public User Check(User user)
        {
            Command command = new Command("CSP_CheckUser");
            command.AddParameter("Email", user.Email);
            command.AddParameter("Login", user.Login);
            command.AddParameter("Password", user.Password);

            return _connection.ExecuteReader(command, (reader) => reader.MapTo<User>()).SingleOrDefault();
        }


        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteUser");
            command.AddParameter("Id", id);
            //command.AddParameter("Table", "User");
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<User> GetAll()
        {
            Command command = new Command("CSP_GetAllUsers");
            return _connection.ExecuteReader(command, (reader) => reader.MapTo<User>());
        }

        public User GetById(int id)
        {
            Command command = new Command("CSP_GetUserById");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, (reader) => reader.MapTo<User>()).SingleOrDefault();
        }

        public int Insert(User entity)
        {
            Command command = new Command("CSP_AddUser");
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Login", entity.Login);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Password", entity.Password);
            command.AddParameter("BirthDate", ((object)entity.BirthDate) ?? DBNull.Value);
            command.AddParameter("Salt", entity.Salt);
            command.AddParameter("Role", entity.Role);
            command.AddParameter("Active", entity.Active);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(User entity)
        {
            Command command = new Command("CSP_UpdateUser");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("BirthDate", (object)entity.BirthDate ?? DBNull.Value);
            command.AddParameter("Role", entity.Role);
            return _connection.ExecuteNonQuery(command) > 0;
        }
    }
}
