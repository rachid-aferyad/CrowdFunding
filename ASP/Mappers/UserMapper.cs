using CrowdFunding.ASP.Models;
using CrowdFunding.ASP.Models.Users;
using CrowdFunding.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdFunding.ASP.Mappers
{
    public static class UserMapper
    {
        public static User ToPL(this UserBO entity)
        {
            if (entity is null) return null;
            return new User(entity);
        }
        public static UserBO ToDAL(this User entity)
        {
            if (entity is null) return null;
            return new UserBO(entity.Id,
                entity.Login,
                entity.Email,
                entity.FirstName,
                entity.LastName,
                entity.Password,
                entity.BirthDate,
                entity.Active,
                entity.Salt,
                entity.Role);
        }
    }
}