using CrowdFunding.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdFunding.ASP.Models.Projects
{
    public class ProjectListingItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalFunding { get; set; }
        public decimal FundingCeiling { get; set; }
        public string VideoLink { get; set; }
        public DateTime CreationDate { get; set; }

        public ProjectListingItem()
        {

        }
        public ProjectListingItem(ProjectBO entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
            VideoLink = entity.VideoLink;
            TotalFunding = entity.TotalFunding;
            CreationDate = entity.CreationDate;
        }
    }
}