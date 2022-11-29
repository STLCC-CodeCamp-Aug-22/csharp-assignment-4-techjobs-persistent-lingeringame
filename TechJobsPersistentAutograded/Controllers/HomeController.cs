﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;
using TechJobsPersistentAutograded.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistentAutograded.Controllers
{

    public class HomeController : Controller

    {
        private JobRepository _repo;

        public HomeController(JobRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()

        {
            IEnumerable<Job> jobs = _repo.GetAllJobs();

            return View(jobs);
        }


        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> possibleEmployers = _repo.GetAllEmployers().ToList();
            List<Skill> possibleSkills = _repo.GetAllSkills().ToList();
            AddJobViewModel viewModel = new AddJobViewModel(possibleEmployers, possibleSkills);
            return View(viewModel);
        }


        public IActionResult ProcessAddJobForm(AddJobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Job theJob = new Job
                {
                    Name = viewModel.Name,
                    Employer = _repo.FindEmployerById(viewModel.EmployerId),
                    EmployerId = viewModel.EmployerId
                };
                //_repo.AddNewJob(theJob);
                //_repo.SaveChanges();
                return Redirect("Index"); // Left off on Part 2, Progress Check before Test It with SQL
            }

            return View("AddJob");
        }


        public IActionResult Detail(int id)
        {
            Job theJob = _repo.FindJobById(id);

            List<JobSkill> jobSkills = _repo.FindSkillsForJob(id).ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }

    }

}


