using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// author ag306

namespace BasketOfFruit
{
    public class Fruit
    {
        // Declare variables for class Fruit
        private string fName;
        private int grams, calsPerGram;
        private bool edible;

        // Builds the constructor for class Fruit
        // assign them with initials that can be passed 
        public Fruit(string n,int g, int c, bool e) 
        {
            grams = g;
            calsPerGram = c;
            edible = e;
            fName = n;
        }

        // Calculates the total calories of a chosen fruit
        // Returns the result to be displayed
        public int totalCalories()  
        {
            return grams * calsPerGram;
        }

        // Passes all the info of a chosen fruit to be displayed
        // One out of two different results
        public string getFruitInfo()  
        {
            string s;
            if (edible == true) // if Check Box ticked the fruit is edible and all info displayed
            {

                s = fName + " is yummy and it has " + totalCalories() + " calories!";
            
            }
            else  // if Check Box is not ticked then returns false with a message
            {
                s = "Hands off! " + fName + " is not edible!";
            }
            return s; // returns the info true/false
        }
    }
}