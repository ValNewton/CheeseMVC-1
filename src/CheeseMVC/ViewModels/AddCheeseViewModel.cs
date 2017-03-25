using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Describe your cheese, sir!")]
        public string Description { get; set; } = "";
    }
}