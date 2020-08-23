using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Views.Projects
{
    public class VProjectListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string LevelType { get; set; }

        //Creation
        public DateTime CreationDate { get; set; }

        //Funding
        public decimal TotalFunding { get; set; }
        public decimal FundingCeiling { get; set; }
    }
}
