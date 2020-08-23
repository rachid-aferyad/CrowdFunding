using CrowdFunding.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Views.Projects
{
    public class VProjectDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string LevelType { get; set; }
        public int NumberFunders { get; set; }

        //Creation
        public DateTime CreationDate { get; set; }

        public decimal TotalFunding { get; set; }
        public decimal FundingCeiling { get; set; }

        //Category
        //public int categoryId { get; set; }
        //public string categoryName { get; set; }

        //Level
        //public int levelId { get; set; }
        //public string levelTitle { get; set; }

        //Funding
        //public DateTime fundingDate { get; set; }
    }
}
