using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must contain 1-100 characters")]
        public string Name { get; set; }
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers { get; set; }
        public int SkillId { get; set; }
        public List<Skill> Skills { get; set; }

        public AddJobViewModel()
        {

        }
        public AddJobViewModel(List<Employer> possibleEmployers, List<Skill> skills)
        {
            Employers = new List<SelectListItem>();
            foreach(var emp in possibleEmployers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = emp.Id.ToString(),
                    Text = emp.Name
                });
            }

            Skills = new List<Skill>();
            foreach(var skill in skills)
            {
                Skills.Add(skill);
            }
        }
    }
}
