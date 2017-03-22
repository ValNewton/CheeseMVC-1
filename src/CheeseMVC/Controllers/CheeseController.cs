using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CheeseMVC.Models;
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
            ViewBag.cheeses = CheeseData.GetAll();

            // view defaults to action name: Index.cshtml
            // /Views/Cheese/Index.cshtml
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.error = "";

            // /Views/Cheese/Add.cshtml
            return View();
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
        public IActionResult NewCheese(Cheese newCheese)
        {
            ViewBag.error = "";
  
            // add new cheese to static class list
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
    }
}
