using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// author ag306

// HOME PAGE
/* Application that takes 3 inputs from user (Fruit name, Fruit weight and Fruit calories per gram).
 * Calculates the total calories of chosen fruit.
 * Asks the user to check if the fruit is edible or not. According to their choice suitable message is displayed.
 * Every time the user presses the button, a new info about a chosen fruit is appended to the list.
 */
// DRINKS PAGE
/* The Drinks page which is part of this application lets the user to choose a fruit and type of drink from dropdown list
 * Asks the user to enter the fruit weight as well in order to be able the calculate the total cost
 * Then the result is displayed as a message in List Box
 * Every next drink mix is appended to the List Box
 */
namespace BasketOfFruit
{
    public partial class _Default : System.Web.UI.Page
    {
        // Declares lists
        List<Fruit> myBasket;
        List<Beverage> myDrinkFruit; 

        protected void Page_Load(object sender, EventArgs e)
        {
            // checks whether the Session is empty or not, that holds all the strings to be displayed
            if (Session["listSession"] == null)
            {
                myBasket = new List<Fruit>();
                Session["listSession"] = myBasket;
            }
            else
            {
                myBasket = (List<Fruit>)Session["listSession"];
            }

            // checks whether the Session that hold the fruit names is empty or not
            if (Session["listFruit"] == null)
            {
                myDrinkFruit = new List<Beverage>();
                Session["listFruit"] = myDrinkFruit;
            }
            else
            {
                myDrinkFruit = (List<Beverage>)Session["listFruit"];
            }
        }

        // Button adds the info to the listbox
        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear(); // Clears content of list
            
            // new object f that will gather and pass all the info to class Fruit
            // (string n,int g, int c, bool e) - Fruit name, weight, calories, edible or not
            Fruit f = new Fruit(TbxName.Text, int.Parse(TbxWeight.Text),
                      int.Parse(TbxCal.Text), CheckBox1.Checked);

            // save and add the chosen fruit's info to the basket 
            myBasket = (List<Fruit>)Session["listSession"]; 
            myBasket.Add(f);

            // Append to list and
            // display every next string in the basket
            foreach (var item in myBasket)
            {
                ListBox1.Items.Add(item.getFruitInfo());
            }

            // new object that passes the fruit name to Beverage class
            Beverage fruit = new Beverage(TbxName.Text);

            // a list that will hold all the fruit names that the user enters
            myDrinkFruit = (List<Beverage>)Session["listFruit"];
            myDrinkFruit.Add(fruit);
            Session["listFruit"] = myDrinkFruit; // saves the list to Session to use it on the Drinks page

            // Clear user inputs
            TbxName.Text = "";
            TbxWeight.Text = "";
            TbxCal.Text = "";

        }
    }
}