using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        private static List<Cheese> cheeses = new List<Cheese>();

        // GetAll
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        // Add
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        // Remove
        public static void Remove(int cheeseId)
        {
            Cheese cheeseToRemove = GetById(cheeseId);
            cheeses.Remove(cheeseToRemove);
        }
        
        // GetById
        public static Cheese GetById(int cheeseId)
        {
            return cheeses.Single(cheese => cheese.CheeseId == cheeseId);
        }
    }
}
