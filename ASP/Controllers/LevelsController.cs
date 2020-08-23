using CrowdFunding.ASP.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class LevelsController : Controller
    {
        // GET: Level
        public ActionResult Index()
        {
            return View();
        }

        // GET: Level/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Level/Create
        [HttpPost]
        public ActionResult Create(Level level)
        {
            try
            {
                // TODO: Add insert logic here

                return View(new Level());
            }
            catch
            {
                return View();
            }
        }

        // GET: Level/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Level/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Level/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Level/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
