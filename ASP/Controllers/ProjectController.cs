using CrowdFunding.ASP.Models.Categories;
using CrowdFunding.ASP.Models.Projects;
using CrowdFunding.BLL.Services;
using CrowdFunding.BLL.Services.Implementations;
using CrowdFunding.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdFunding.ASP.Models;
using CrowdFunding.BLL.Mappers;
using CrowdFunding.ASP.Mappers;
using CrowdFunding.BLL.Repositories.Implementations;

namespace CrowdFunding.ASP.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService<int, ProjectBO> _projectService;
        private IBankAccountService<int, BankAccountBO> _bankAccountService;
        private ICategoryService<int, CategoryBO> _categoryService;
        private IFundingService<int, FundingBO> _fundingService;
        private ILevelService<int, LevelBO> _levelService;

        public ProjectController()
        {
            _projectService = new ProjectService();
            _bankAccountService = new BankAccountService();
            _categoryService = new CategoryService();
            _fundingService = new FundingService();
            _levelService = new LevelService();
        }

        // GET: Project
        //[Route("/projects")]
        public ActionResult Index()
        {
            IEnumerable<ProjectListingItem> projects = _projectService.GetAll().Select(p => p.MapTo<ProjectListingItem>());
            return View(projects);
        }

        [HttpGet]
        //[Route("/projects/new")]
        public ActionResult Create()
        {
            CreateProjectForm createProjectForm = new CreateProjectForm();
            //createProjectForm.Levels = new List<Level>();
            //createProjectForm.Levels.Add(new Level());

            createProjectForm.Categories = _categoryService.GetAll()
                .Select(c => new SelectListItem 
                { Text = c.Name, 
                    Value = c.Id.ToString()
                }).ToList();

            return View(createProjectForm);
        }

        [HttpPost]
        //[Route("/projects/new")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProjectForm form, bool? levelsCheckBox)
        {
            if (ModelState.IsValid)
            {
                if(form.Categories.Count(c => c.Selected) > 0)
                {
                    try
                    {
                        BankAccount bankAccount = new BankAccount()
                        {
                            AccountNumber = form.AccountNumber,
                            Country = form.Country
                        };

                        IEnumerable<int> categories = form.Categories.Where(c => c.Selected).Select(c => int.Parse(c.Value));
                        ProjectBO project = form.MapTo<ProjectBO>();
                        IEnumerable<LevelBO> levels = form.Levels?.Select(l => l.MapTo<LevelBO>());

                        _projectService.Save(project, bankAccount.MapTo<BankAccountBO>(), categories, levels);

                        return RedirectToAction(nameof(Index));
                    }
                    catch(Exception e)
                    {
                        ViewBag.Exception = e.Message;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sélectionnez au moins une catégorie");
                }
            }

            return View(form);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddLevelToProject(CreateProjectForm form)
        {
            if(form.Levels == null)
            {
                form.Levels = new List<Level>();
            }
            form.Levels.Add(new Level());
            return PartialView("Levels", form);
        }

        [HttpPost]
        public ActionResult RemoveLevelsToProject(CreateProjectForm form)
        {
            if (form.Levels != null)
            {
                form.Levels = null;
            }
            return View("Create", form);
        }
        public ActionResult Details(int id)
        {
            ProjectDetails project = _projectService.GetById(id).MapTo<ProjectDetails>();
            project.Levels = _levelService.GetByProject(id).Select(l => l.MapTo<Level>());
            project.Funding = _fundingService.GetByProject(id).Select(f => f.MapTo<Funding>()).ToList();

            ViewBag.MaxProgress = (int) Math.Floor((project.TotalFunding/project.FundingCeiling) * 100);

            return View(project);
        }

        [HttpGet]
        [Route("project/fund/{projectId:int:min(0)}")]
        public ActionResult Fund(int projectId)
        {
            ProjectDetails projectDetails = _projectService.GetById(projectId)?.MapTo<ProjectDetails>();
            projectDetails.Funding = _fundingService.GetByProject(projectId).Select(f => f.MapTo<Funding>()).ToList();
            projectDetails.Levels = _levelService.GetByProject(projectId).Select(l => l.MapTo<Level>());
            projectDetails.Funding.Add(new Funding());

            
            //Funding funding = new Funding()
            //{
            //    Levels = _levelService.GetByProject(projectId)?.Select(l => l.MapTo<Level>()),
            //    ProjectTitle = projectDetails.Title,
            //    FundingCeiling = projectDetails.FundingCeiling,
            //    TotalFunding = projectDetails.TotalFunding,
            //    NumberFunders = projectDetails.NumberFunders
            //};

            return View(projectDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("project/fund/{projectId:int:min(0)}")]
        public ActionResult Fund(int projectId, decimal amount)
        {
            if (ModelState.IsValid)
            {
                if (amount > 0)
                {
                    try
                    {
                        //ajouter ProjectId et FunderId
                        Funding funding = new Funding()
                        {
                            ProjectId = projectId,
                            Amount = amount
                        };
                        _fundingService.Save(funding.MapTo<FundingBO>());
                        return RedirectToAction(nameof(Details), new { id = projectId });
                    }
                    catch (Exception e)
                    {
                        ViewBag.Exception = e.Message;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Ajouter un montant");
                }
            }
            ProjectDetails projectDetails = _projectService.GetById(projectId).MapTo<ProjectDetails>();
            return View(projectDetails);
        }
    
    }
}