using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Models.Users
{
    public class UserCompanyDAL
    {
		//User
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

		//Company
		public int CompanyId { get; set; }
		public string CompanyName { get; set; }
		public string CompanyVatNumber { get; set; }
		public string CompanyAddressMailBox { get; set; }
		public int CompanyAddressNumber { get; set; }
		public string CompanyAddressStreet { get; set; }
		public string CompanyAddressCity { get; set; }
		public int CompanyAddressZipCode { get; set; }
		public string CompanyAddressCountry { get; set; }

	}
}
