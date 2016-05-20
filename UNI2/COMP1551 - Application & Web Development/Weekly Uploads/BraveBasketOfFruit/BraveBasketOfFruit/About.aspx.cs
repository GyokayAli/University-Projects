using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// author ag306

/* This page lets the user to choose a fruit and type of drink from dropdown list
 * Asks the user to enter the fruit weight as well in order to be able the calculate the total cost
 * Then the result is displayed as a message in List Box
 * Every next drink mix is appended to the List Box
 */
namespace BasketOfFruit
{
    public partial class About : System.Web.UI.Page
    {
        Beverage b;
        // create lists of type Beverage
        List<Beverage> drinkBasket;
        List<Beverage> fruitChooser;

        protected void Page_Load(object sender, EventArgs e)
        {
            // checks if the Session that hold the drink messages is empty or not
            if (Session["listMixer"] == null)
            {
                drinkBasket = new List<Beverage>();
                Session["listMixer"] = drinkBasket; // saves to Session
            }
            else
            {
                drinkBasket = (List<Beverage>)Session["listMixer"]; // and back using casting
            }
         
            // Makes sure that the Fruit chooser is filled only the first time the page is loaded
            if (!Page.IsPostBack)
            {
                fruitChooser = (List<Beverage>)Session["listFruit"];

                foreach (var item in fruitChooser)            // every next Fruit added by the user.. 
                {                                             // ..is added to Fruit chooser dropdown list
                    DropDownList1.Items.Add(item.getFruit());
                }
            }
            
           
            
        }

        // Button to mix everything together entered by the user and create e.g Cocktail or Juice
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            ListBox1.Items.Clear(); // clears listbox and prevents duplicates
            
            // new object that passes 5 parameters to Beverage class
            // Selected fruit, drink, drink cost and weight
            b = new Beverage(DropBeverage.SelectedItem.ToString(), DropDownList1.SelectedItem.ToString(),
                Double.Parse(TbxFruitWeight.Text), Double.Parse(DropBeverage.SelectedItem.Value));

            drinkBasket = (List<Beverage>)Session["listMixer"]; // saves the Session to list 
            drinkBasket.Add(b);

            // every next string in the list is appended to the List Box
            foreach (var item in drinkBasket)
            {
                ListBox1.Items.Add(item.getBeverageInfo());
            }
      
        }
    }
}