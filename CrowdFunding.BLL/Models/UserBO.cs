using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Models
{
    public class UserBO : BaseEntity
    {
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime? BirthDate { get; set; }
		public string Salt { get; set; }
		public bool Active { get; set; }
		public UserRole Role { get; set; }

		public UserBO()
		{

		}

		public UserBO(User user)
		{
			Id = user.Id;
			FirstName = user.FirstName;
			LastName = user.LastName;
			Login = user.Login;
			Email = user.Email;
			Password = user.Password;
			BirthDate = user.BirthDate;
			Salt = user.Salt;
			Role = (user.Role == "SIMPLE_USER") ? UserRole.SIMPLE_USER : (user.Role == "ADMIN") ? UserRole.ADMIN : UserRole.COMPANY;
			Active = user.Active;
		}

		public UserBO(int id, string login, string email, string firstName, string lastName, string password, DateTime? birthDate, bool active, string salt, UserRole role)
		{
			Id = id;
			Login = login;
			Email = email;
			FirstName = firstName;
			LastName = lastName;
			Password = password;
			BirthDate = birthDate;
			Active = active;
			Salt = salt;
			Role = role;
		}
	}
}
