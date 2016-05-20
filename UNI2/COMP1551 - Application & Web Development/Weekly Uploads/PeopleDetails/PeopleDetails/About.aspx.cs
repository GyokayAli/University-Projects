using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// author ag306
namespace PeopleDetails
{
    /* Page used to display all the submissions of People's Details
     * List is filled automatically when entered the page
     */
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBox1.Items.Clear(); // Clears the list to prevent duplicates

            List<Person> details = new List<Person>(); // Creates new list of type Person
            details = (List<Person>)Session["listSession"]; // Saves details from Session created in the Default page
                                                            // to list

            // Adds every next item/string in the list to the listbox to display
            foreach (var inputString in details)
            {
                ListBox1.Items.Add(inputString.PresentPerson());
            }
        } 
    }
}