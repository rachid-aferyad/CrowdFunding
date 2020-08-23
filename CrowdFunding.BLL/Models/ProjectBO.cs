using CrowdFunding.BLL.Services;
using CrowdFunding.BLL.Services.Implementations;
using CrowdFunding.DAL.Models;
using CrowdFunding.DAL.Repositories.Implementations;
using CrowdFunding.DAL.Views.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Models
{
    public class ProjectBO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public bool Active { get; set; }
        public bool ActivedForValidation { get; set; }
        public decimal TotalFunding { get; set; }
        public decimal FundingCeiling { get; set; }
        public LevelType LevelType { get; set; }
        public int NumberFunders { get; set; }

        public IEnumerable<FundingBO> Funding { get; set; }
        //Creation
        public DateTime CreationDate { get; set; }
        private int CreatorId { get; set; }
        private UserBO _creator;
        public UserBO Creator
        {
            get 
            { 
                IUserService<int, UserBO> userService = new UserService();
                if(Creator == null)
                {
                    if(CreatorId != null)
                    {
                        _creator = userService.GetById(CreatorId);
                    }
                    
                }
                //else
                //{
                //    _creator = userService.GetById(2);
                //}
                return _creator; 
            }
            set 
            { 
                CreatorId = value.Id; 
            }
        }

        //Validation
        public DateTime? ValidationDate { get; set; }
        private int? ValidatorId { get; set; }
        private UserBO _validator;
        public UserBO Validator
        {
            get 
            { 
                if(_validator == null)
                {
                    if(ValidatorId != null)
                    {
                        IUserService<int, UserBO> userService = new UserService();
                        _validator = userService.GetById((int)ValidatorId);
                    }
                }
                return _validator; 
            }
            set 
            { 
                ValidatorId = value.Id; 
            }
        }

        //BankAccount
        private int BankAccountId { get; set; }
        private BankAccountBO _bankAccount;
        public BankAccountBO BankAccount
        {
            get 
            { 
                if(_bankAccount == null)
                {
                    if(BankAccountId != null)
                    {
                        IBaseService<int, BankAccountBO> bankAccountService = new BankAccountService();
                        _bankAccount = bankAccountService.GetById(BankAccountId);
                    }
                }
                return _bankAccount;
            }
            set 
            {
                if(BankAccountId == null)
                {
                    IBaseService<int, BankAccountBO> bankAccountService = new BankAccountService();
                    BankAccountId = bankAccountService.Save(value);
                    BankAccount = value;
                }
            }
        }

        //Levels
        //private IEnumerable<LevelBO> Levels;
        //public IEnumerable<LevelBO> Levels
        //{
        //    get 
        //    { 

        //        if(Levels == null)
        //        {
        //            ILevelService<int, LevelBO> levelService = new LevelService();
        //            Levels = levelService.GetByProject(Id);
        //        }
        //        return Levels;
        //    }
        //    set 
        //    {
        //        /*value.ToList().ForEach(l =>
        //        {
        //            ILevelService<int, LevelBO> levelService = new LevelService();
        //            l.ProjectId = Id;
        //            levelService.Save(l);
        //        });*/

        //        value.ToList().ForEach(l =>
        //        {
        //            l.ProjectId = Id;
        //        });
        //    }
        //}

        //Categories
        //private IEnumerable<CategoryBO> Categories;
        //public IEnumerable<CategoryBO> Categories
        //{
        //    get
        //    {

        //        if (Categories == null)
        //        {
        //            ICategoryService<int, CategoryBO> categoryService = new CategoryService();
        //            Categories = categoryService.GetByProject(Id);
        //        }
        //        return Categories;
        //    }
        //    set
        //    {
        //        /*value.ToList().ForEach(l =>
        //        {
        //            ILevelService<int, LevelBO> levelService = new LevelService();
        //            l.ProjectId = Id;
        //            levelService.Save(l);
        //        });*/

        //        Categories = value;
        //    }
        //}

        public ProjectBO()
        {

        }

        public ProjectBO(Project entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
            VideoLink = entity.VideoLink;
            Active = entity.Active;
            ActivedForValidation = entity.ActivedForValidation;
            LevelType = (entity.LevelType == "FIXED") ? LevelType.FIXED : LevelType.CUMULATED;
            CreationDate = entity.CreationDate;
            CreatorId = entity.CreatorId;
            ValidationDate = entity.ValidationDate;
            ValidatorId = entity.ValidatorId;
            BankAccountId = entity.BankAccountId;
        }

        public ProjectBO(VProjectListing entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
            VideoLink = entity.VideoLink;
            LevelType = (entity.LevelType == "FIXED") ? LevelType.FIXED : LevelType.CUMULATED;
            CreationDate = entity.CreationDate;
            TotalFunding = entity.TotalFunding;
        }

        public ProjectBO(int id, string title, string description, string videoLink, decimal fundingCeiling, LevelType levelType, int creatorId, BankAccountBO bankAccount)
        {
            Id = id;
            Title = title;
            Description = description;
            VideoLink = videoLink;
            FundingCeiling = fundingCeiling;
            LevelType = levelType;
            CreatorId = creatorId;
            BankAccount = bankAccount;
        }

        public ProjectBO(int id, string title, string description, decimal fundingCeiling, LevelType levelType, string videoLink, BankAccountBO bankAccount)
        {
            Id = id;
            Title = title;
            Description = description;
            FundingCeiling = fundingCeiling;
            LevelType = levelType;
            VideoLink = videoLink;
            BankAccount = bankAccount;
        }
    }
}
