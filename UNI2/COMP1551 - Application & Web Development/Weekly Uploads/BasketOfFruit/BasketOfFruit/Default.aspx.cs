using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//author ag306

/* Application that takes 3 inputs from user (Fruit name, Fruit weight and Fruit calories per gram).
 * Calculates the total calories of chosen fruit.
 * Asks the user to check if the fruit is edible or not. According to their choice suitable message is displayed.
 * Every time the user presses the button, a new info about a chosen fruit is appended to the list.
 */
namespace BasketOfFruit
{
    public partial class _Default : System.Web.UI.Page
    {
        // Declares a list
        List<Fruit> myBasket;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // Checks if page is loaded for the first time
            {
                myBasket = new List<Fruit>();       // creates a new list
                Session["listSession"] = myBasket; // saves the content of list as a Session
            }
        }

        // Adds the fruit info to the list when clicked
        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear(); // Clears content of list
            
            // new object f that will gather and pass all the info to class Fruit
            // (string n,int g, int c, bool e) - 4 parameters
            Fruit f = new Fruit(TbxName.Text, int.Parse(TbxWeight.Text),
                      int.Parse(TbxCal.Text), CheckBox1.Checked);

            // save and add the chosen fruit info to the basket 
            myBasket = (List<Fruit>)Session["listSession"]; 
            myBasket.Add(f);

            // Append to list and
            // display every next item in the basket
            foreach (var item in myBasket)
            {
                ListBox1.Items.Add(item.getFruitInfo());
            }

        }
    }
}