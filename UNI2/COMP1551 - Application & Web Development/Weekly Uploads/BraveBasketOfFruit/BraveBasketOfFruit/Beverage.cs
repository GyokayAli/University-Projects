using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// author ag306

namespace BasketOfFruit
{
    public class Beverage
    {
        // Declare variables for class Beverage
        private string drinkName, fruitName;
        private double kilo, drinkCost;
      
        // Builds the constructor for class Beverage
        // assign them with initials that can be passed 
        public Beverage(string dn, string fn, double k, double dc) 
        {
            drinkName = dn;
            fruitName = fn;
            kilo = k;
            drinkCost = dc;    
        }

        // constructor to be used to pass the fruit name entered by the user to the Drinks page
        public Beverage(string fn)
        {
            fruitName = fn;
        }
        
        // gets the fruit name entered by the user
        public string getFruit()
        {
            return fruitName;
        }
      
        // calculates the cost to make a chosen drink
        public double totalCost()  
        {
            return kilo * drinkCost;
        }

        // Passes all the info of a chosen fruit to be displayed
        public string getBeverageInfo()  
        {   
            string s = "The " + fruitName + " " + drinkName + " will cost you £" + totalCost() + 
                    "! But believe me it is fantastic!";
     
            return s; 
        }
    }
}