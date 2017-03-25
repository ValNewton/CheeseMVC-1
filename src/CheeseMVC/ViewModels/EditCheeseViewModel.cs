using CheeseMVC.Models;

namespace CheeseMVC.ViewModels
{
    public class EditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }

        public EditCheeseViewModel()
        {
        }

        public EditCheeseViewModel(Cheese cheese)
        {
            CheeseId = cheese.CheeseId;
            Name = cheese.Name;
            Description = cheese.Description;
            Type = cheese.Type;
        }
    }
}