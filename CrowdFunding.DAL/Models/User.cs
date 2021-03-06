﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public DateTime? BirthDate { get; set; }
		public bool Active { get; set; }
		public string Role { get; set; }
	}
}
