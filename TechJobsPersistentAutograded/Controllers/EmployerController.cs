using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistentAutograded.Data;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistentAutograded.Controllers
{
    public class EmployerController : Controller
    {
        private JobRepository _repo;
        public EmployerController(JobRepository repo)
        {
            _repo = repo;   
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Employer> Employers = _repo.GetAllEmployers();

            return View(Employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel viewModel = new AddEmployerViewModel();
            return View(viewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Employer theEmployer = new Employer
                {
                    Name = viewModel.Name,
                    Location = viewModel.Location
                };
                _repo.AddNewEmployer(theEmployer);
                _repo.SaveChanges();
                return Redirect("/Employer");
            }
            return View("Add");
        }

        public IActionResult About(int id)
        {
            Employer theEmployer = _repo.FindEmployerById(id);
            return View(theEmployer);
        }
    }
}

