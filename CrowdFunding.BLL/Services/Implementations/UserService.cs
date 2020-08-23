using CrowdFunding.BLL.Models;
using CrowdFunding.BLL.Mappers;
using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Repositories;
using CrowdFunding.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFunding.BLL.Services.Implementations
{
    public class UserService : IUserService<int, UserBO>
    {
        private IUserRepository<int, User> _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public UserBO Check(UserBO entity)
        {
            return _userRepository.Check(entity.MapTo<User>()).ToBLL();
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<UserBO> GetAll()
        {
            return _userRepository.GetAll().Select(u => u.ToBLL());
        }

        public UserBO GetById(int id)
        {
            return _userRepository.GetById(id).ToBLL();
        }

        public int Save(UserBO entity)
        {
            return _userRepository.Insert(entity.ToDAL());
        }

        public bool Update(int id, UserBO entity)
        {
            User user = entity.MapTo<User>();
            user.Id = id;
            return _userRepository.Update(user);
        }
    }
}
