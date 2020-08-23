using CrowdFunding.ASP.Models.Projects;
using CrowdFunding.BLL.Mappers;
using CrowdFunding.BLL.Models;
using CrowdFunding.BLL.Services;
using CrowdFunding.BLL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        private IProjectService<int, ProjectBO> ProjectService;

        public HomeController()
        {
            ProjectService = new ProjectService();
        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<ProjectListingItem> projects = ProjectService.GetAll().Select(p => p.MapTo<ProjectListingItem>());
            return View(projects);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}