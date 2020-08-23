using CrowdFunding.BLL.Models;
using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Views.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class ProjectMapper
    {
        public static Project ToDAL(this ProjectBO entity)
        {
            if (entity == null) return null;
            return new Project
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                VideoLink = entity.VideoLink,
                LevelType = entity.LevelType.ToString(),
                //Active = entity.Active,
                //ActivedForValidation = entity.ActivedForValidation,
                //CreationDate = entity.CreationDate,
                //CreatorId = entity.Creator.Id,
                //ValidationDate = entity.ValidationDate,
                //ValidatorId = entity.Validator?.Id,
                BankAccountId = entity.BankAccount.Id
               };
        }
        public static ProjectBO ToBLL(this Project entity)
        {
            if (entity == null) return null;
            return new ProjectBO(entity);
        }

        public static VProjectListing ToListingDAL(this ProjectBO entity)
        {
            if (entity == null) return null;
            return new VProjectListing
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                VideoLink = entity.VideoLink,
                LevelType = entity.LevelType.ToString(),
                CreationDate = entity.CreationDate,
                TotalFunding = entity.TotalFunding
            };
        }
        public static ProjectBO ToListingBLL(this VProjectListing entity)
        {
            if (entity == null) return null;
            return new ProjectBO(entity);
        }

        //public static Project ToDAL(this ProjectBO entity)
        //{
        //    if (entity == null) return null;
        //    return new Project
        //    {
        //        id = entity.Id,
        //        title = entity.Title,
        //        description = entity.Description,
        //        totalFunding = entity.TotalFunding,
        //        videoLink = entity.VideoLink
        //    };
        //}
        //public static ProjectBO ToBLL(this Project entity)
        //{
        //    if (entity == null) return null;
        //    return new ProjectBO(entity);
        //}
    }
}
