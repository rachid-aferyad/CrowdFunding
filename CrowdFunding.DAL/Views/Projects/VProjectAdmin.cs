using CrowdFunding.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Views.Projects
{
    public class VProjectAdmin
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public bool Active { get; set; }
        public bool ActivatedForValidation { get; set; }
        public string LevelType { get; set; }

        //Creation
        public int CreatorId { get; set; }
        public string CreatorFirstName { get; set; }
        public string CreatorLastName { get; set; }
        public DateTime CreationDate { get; set; }

        //Validation
        public int? ValidatorId { get; set; }
        public string CalidatorFirstName { get; set; }
        public string CalidatorLastName { get; set; }
        public DateTime? CalidationDate { get; set; }
        public decimal TotalFunding { get; set; }
        public decimal FundingCeiling { get; set; }

        //Category
        //public int categoryId { get; set; }
        //public string categoryName { get; set; }

        //Level
        //public int levelId { get; set; }
        //public string levelTitle { get; set; }

        //Modification
       // public DateTime modificationDate { get; set; }

        //Rejection
        //public int rejectorId { get; set; }
        //public string rejectorLastName { get; set; }
        //public string rejectorFirstName { get; set; }
        //public DateTime rejectionDate { get; set; }

        //Funding
        //public int funderId { get; set; }
        //public string funderFirstName { get; set; }
        //public string funderLastName { get; set; }
        //public DateTime fundingDate { get; set; }
    }
}
