using CrowdFunding.ASP.Models.Categories;
using CrowdFunding.BLL.Mappers;
using CrowdFunding.BLL.Models;
using CrowdFunding.BLL.Services;
using CrowdFunding.BLL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdFunding.ASP.Models.Projects
{
    public class CreateProjectForm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Le titre est oblidatoire")]
        [DisplayName("TITRE")]
        public string Title { get; set; }
        [DisplayName("DESCRIPTION")]
        public string Description { get; set; }
        [DisplayName("LIEN VERS UNE VIDÉO DESCRIPTIVE")]
        public string VideoLink { get; set; }
        [DisplayName("TYPE DES PALIERS")]
        public LevelType LevelType { get; set; }
        [Required(ErrorMessage = "Entrez l'objectif du financement")]
        [Range(100, int.MaxValue, ErrorMessage = "L'objectif de financement doit être supérieur à 100")]
        [DisplayName("OBJECTIF DE FINANCEMENT")]
        public decimal FundingCeiling { get; set; }
        [Required(ErrorMessage = "Le numéro de compte est obligatoire")]
        [DisplayName("NUMERO DE COMPTE")]
        public string AccountNumber { get; set; }
        [DisplayName("PAYS")]
        public string Country { get; set; }
        [DisplayName("CATEGORIES")]
        public IList<SelectListItem> Categories { get; set; }

        [DisplayName("PALIERS")]
        public IList<Level> Levels { get; set; }

        public bool IsLevelsChecked { get; set; }

        //public bool IsLevelSelected { get; set; }
        //[DisplayName("OBJECTIF DE FINANCEMENT")]
        //[DisplayName("Palier")]
        //public Level Level { get; set; }

        //private IEnumerable<Level> _levels { get; set; }
        //{
        //    get
        //    {
        //        if (_levels == null)
        //        {
        //            ILevelService<int, LevelBO> levelService = new LevelService();
        //            _levels = levelService.GetByProject(Id).Select(l => l.MapTo<Level>());
        //        }
        //        return _levels;
        //    }
        //    set
        //    {
        //        _levels = value;
        //    }
        //}

        //public int BankAccountId { get; set; }
        //IEnumerable<Category> CategoriesId { get; set; }
        //[Required]
        //[Display(Name = "Catégories")]
        //public string SelectedCategorie { get; set; }

        //public List<SelectListItem> SelectedCategoriesList { get; set; }
        //public List<SelectListItem> CategoriesList { get; set; }

        //private IEnumerable<Category> _categories;
        //{
        //    get
        //    {
        //        if (_categories == null)
        //        {
        //            ICategoryService<int, CategoryBO> categoryService = new CategoryService();
        //            _categories = categoryService.GetAll().Select(c => c.MapTo<Category>());
        //        }
        //        return _categories;
        //    }
        //    set
        //    {
        //        _categories = value;
        //    }
        //}

        public CreateProjectForm()
        {

        }
    }
}