using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.ASP.Models.Projects
{
    public class Funding
    {
        public int Id { get; set; }
        public int FunderId { get; set; }
        [DisplayName("Montant")]
        public decimal Amount { get; set; }
        [DisplayName("Date")]
        public DateTime FundingDate { get; set; }
        public int ProjectId { get; set; }
        //public string ProjectTitle { get; set; }
        //public decimal TotalFunding { get; set; }
        //public decimal FundingCeiling { get; set; }
        //public int NumberFunders { get; set; }
        //public IEnumerable<Level> Levels { get; set; }
    }
}
