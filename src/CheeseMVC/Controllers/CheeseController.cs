using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    // view location: /Views/Cheese/*
    public class CheeseController : Controller
    {
        // static propery is available to *any* instance
        // of the CheeseController class
        private static Dictionary<string, string> cheeses = new Dictionary<string, string>();

        // Display the list of cheeses
        // GET: /cheese
        public IActionResult Index()
        {
            // data for the view
            ViewBag.cheeses = cheeses;

            // view defaults to action name: Index.cshtml
            // /Views/Cheese/Index.cshtml
            return View();

            // OR render particular view *by name*
            // return View("Index");
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
        [Route("/cheese/add")]
        [HttpPost]
        public IActionResult NewCheese(string name = "", string description = "")
        {
            ViewBag.error = "";
            // valid cheese names: letters and spaces
            Regex validCheeseNamePattern = new Regex(@"[a-zA-Z\s]+");

            if (name == null || !validCheeseNamePattern.IsMatch(name))
            {
                // cheese name is not valid, re-render the form and
                // send an error message
                ViewBag.error = "#fakecheese!";
                return View("Add");
            }
   
            // add new cheese to static class list
            cheeses.Add(name, description);

            // go back to the list of cheeses
            return Redirect("/cheese");
        }

        [Route("/cheese/remove")]
        [HttpGet]
        public IActionResult Remove()
        {
            ViewBag.cheeses = cheeses;
            return View("Remove");
        }

        [Route("/cheese/remove")]
        [HttpPost]
        public IActionResult RemoveManyCheeses(string[] selectedCheeses)
        {
            foreach (string cheeseName in selectedCheeses)
            {
                if (cheeses.ContainsKey(cheeseName))
                {
                    cheeses.Remove(cheeseName);
                }
            }

            return Redirect("/cheese");
        }

        [Route("/cheese/remove/{cheeseName}")]
        [HttpGet]
        public IActionResult RemoveSingleCheese(string cheeseName = "")
        {
            if (cheeses.ContainsKey(cheeseName))
            {
                cheeses.Remove(cheeseName);
            }

            return Redirect("/cheese");
        }
    }
}
