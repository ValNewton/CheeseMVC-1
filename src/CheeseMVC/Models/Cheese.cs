using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int CheeseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private static int nextId = 1;

        private static readonly Regex validCheeseNamePattern = new Regex(@"[a-zA-Z\s]+");

        public Cheese()
        {
            // default constructor is required for model
            // binding in controllers

            CheeseId = nextId;
            nextId += 1;
        }

        public Cheese(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public static bool IsValidName(string name)
        {            
            return name != null && validCheeseNamePattern.IsMatch(name);
        }
    }
}
