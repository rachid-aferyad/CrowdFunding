using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public bool Active { get; set; }
        public bool ActivedForValidation { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ValidationDate { get; set; }
        public string LevelType { get; set; }
        public int CreatorId { get; set; }
        public int? ValidatorId { get; set; }
        public int BankAccountId { get; set; }
        public decimal FundingCeiling { get; set; }
    }
}
