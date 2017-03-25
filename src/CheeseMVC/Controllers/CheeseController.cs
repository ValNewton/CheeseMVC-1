using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    // view location: /Views/Cheese/*
    public class CheeseController : Controller
    {
        // Display the list of cheeses
        // GET: /cheese
        public IActionResult Index()
        {
            // data for the view
            List<Cheese> cheeses = CheeseData.GetAll();

            // view defaults to action name: Index.cshtml
            // /Views/Cheese/Index.cshtml
            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel viewModel = new AddCheeseViewModel();

            // /Views/Cheese/Add.cshtml
            return View(viewModel);
        }

        // by default, the route will be: /Cheese/NewCheese
        // but we want to post the form to the same route
        // from which we loaded it: /Cheese/Add
        //
        // Since the Cheese class has name and description
        // attributes, we can let MVC create a new Cheese
        // object for us, and fill its Name and Descirption
        // properties automagically. Note that:
        // - the Cheese class must have a *default* parameterless
        //   constructor, and 
        // - this does *not* yet perform any validation!
        //
        [Route("/cheese/add")]
        [HttpPost]
        public IActionResult NewCheese(AddCheeseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", viewModel);
            }

            // add new cheese to static class list
            Cheese newCheese = new Cheese(
                viewModel.Name,
                viewModel.Description
            );
            newCheese.Type = viewModel.Type;
            CheeseData.Add(newCheese);

            // go back to the list of cheeses
            return Redirect("/cheese");
        }

        [Route("/cheese/remove")]
        [HttpGet]
        public IActionResult Remove()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            return View("Remove");
        }

        [Route("/cheese/remove")]
        [HttpPost]
        public IActionResult RemoveManyCheeses(int[] cheeseIds)
        {
            foreach (int submittedCheeseId in cheeseIds)
            {
                // remove cheese from cheeses by using LINQ to extract
                // the specific cheese by CheeseId
                CheeseData.Remove(submittedCheeseId);
            }

            return Redirect("/cheese");
        }

        [Route("/cheese/remove/{cheeseId}")]
        [HttpGet]
        public IActionResult RemoveSingleCheese(int cheeseId)
        {
            // remove cheese from cheeses by using LINQ to extract
            // the specific cheese by CheeseId
            CheeseData.Remove(cheeseId);

            return Redirect("/cheese");
        }

        [Route("/cheese/edit")]
        [HttpGet]
        public IActionResult Edit(int cheeseId)
        {
            Cheese cheese = CheeseData.GetById(cheeseId);
            EditCheeseViewModel viewModel = new EditCheeseViewModel(cheese);
            return View(viewModel);
        }

        [Route("/cheese/edit")]
        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel viewModel)
        {
            Cheese cheese = CheeseData.GetById(viewModel.CheeseId);
            cheese.Name = viewModel.Name;
            cheese.Description = viewModel.Description;
            cheese.Type = viewModel.Type;
            return Redirect("/cheese");
        }
    }
}
