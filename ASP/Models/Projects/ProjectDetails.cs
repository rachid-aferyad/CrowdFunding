using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdFunding.ASP.Models.Projects
{
    public class ProjectDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoLink { get; set; }
        public decimal TotalFunding { get; set; }
        public decimal FundingCeiling { get; set; }
        public int NumberFunders { get; set; }
        public DateTime CreationDate { get; set; }
        IEnumerable<int> CategoriesId { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountCountry { get; set; }
        public virtual IList<Funding> Funding { get; set; }
        public IEnumerable<Level> Levels { get; set; }
    }
}