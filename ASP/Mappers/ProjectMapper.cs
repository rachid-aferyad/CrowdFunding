using CrowdFunding.ASP.Models.Projects;
using CrowdFunding.ASP.Models.Users;
using CrowdFunding.BLL.Mappers;
using CrowdFunding.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdFunding.ASP.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectListingItem ToListingPL(this ProjectBO entity)
        {
            if (entity is null) return null;
            return new ProjectListingItem(entity);
        }
        public static ProjectBO ToProjectBO(this CreateProjectForm entity)
        {
            if (entity is null) return null;
            return new ProjectBO(entity.Id,
                entity.Title,
                entity.Description,
                entity.FundingCeiling,
                entity.LevelType,
                entity.VideoLink,
                new BankAccountBO { AccountNumber = entity.AccountNumber, Country = entity.Country});
        }
    }
}