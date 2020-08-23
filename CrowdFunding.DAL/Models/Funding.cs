using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Models
{
    public class Funding
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int FunderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime FundingDate { get; set; }
    }
}
