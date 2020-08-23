using CrowdFunding.BLL.Models;
using CrowdFunding.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class UserMapper
    {
        public static User ToDAL(this UserBO entity)
        {
            if (entity == null) return null;
            return new User
            {
                Id = entity.Id,
                Login = entity.Login,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                BirthDate = entity.BirthDate,
                Active = entity.Active,
                Salt = entity.Salt,
                Role = entity.Role.ToString()   //(entity.Role == C.UserRole.ADMIN) ? "ADMIN" : (entity.Role == C.UserRole.SIMPLE_USER) ? "SIMPLE_USER" : "NOTASSIGNED"
            };
        }
        public static UserBO ToBLL(this User entity)
        {
            if (entity == null) return null;
            return new UserBO(entity);
        }
    }
}
