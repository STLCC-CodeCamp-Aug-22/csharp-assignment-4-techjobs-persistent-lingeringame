using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must contain 1-100 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Location must contain 3-500 characters")]
        public string Location { get; set; }
    }
}
