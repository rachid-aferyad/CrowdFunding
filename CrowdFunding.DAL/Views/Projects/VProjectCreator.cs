using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Views.Projects
{
    public class VProjectCreator
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
        public DateTime CreationDate { get; set; }

        //Validation
        public DateTime? validationDate { get; set; }

        public decimal TotalFunding { get; set; }
        public decimal FundingCeiling { get; set; }

        //Category
        //public int categoryId { get; set; }
        //public string categoryName { get; set; }

        //Level
        ///public int levelId { get; set; }
        //public string levelTitle { get; set; }

        //Modification
        //public DateTime modificationDate { get; set; }

        //Rejection
        //public DateTime rejectionDate { get; set; }
        //public string rejectionComment { get; set; }

        //Funding
        //public DateTime fundingDate { get; set; }
    }
}
