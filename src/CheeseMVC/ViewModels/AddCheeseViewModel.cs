using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Describe your cheese, sir!")]
        public string Description { get; set; } = "";

        public CheeseType Type { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } = 5;

        public Cheese CreateCheese()
        {
            return new Cheese()
            {
                Name = Name,
                Description = Description,
                Type = Type,
                Rating = Rating
            };

        }

        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();

            // <option value="0">Hard</option>
            CheeseTypes.Add(new SelectListItem()
            {
                Value = ((int) CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            // <option value="1">Soft</option>
            CheeseTypes.Add(new SelectListItem()
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            // <option value="2">Fake</option>
            CheeseTypes.Add(new SelectListItem()
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }
    }
}