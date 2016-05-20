using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// author ag306

/* Application that takes from the user 6 inputs (people's details)
 * Their Age, First name, Surname, DoB, Mobile and Gender
 * And all the info is saved in a list and Session, then used to display on the About page
 * Uses PresentPerson() method in order to display everything on the next page
 */
namespace PeopleDetails
{
    public partial class _Default : System.Web.UI.Page
    {
        Person p;
        List<Person> listOfPeople; // creates a list of type Person

        protected void Page_Load(object sender, EventArgs e)
        {
            // every time the page is loaded it checks whether the Session is empty or not
            if (Session["listSession"] == null)
            {
                listOfPeople = new List<Person>();
                Session["listSession"] = listOfPeople; // saves the content of list to Session
            }
            else
            {
                listOfPeople = (List<Person>)Session["listSession"]; // and back using casting
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // new object that passes all the input parameters to class Person
            p = new Person(Int32.Parse(TbxAge.Text), TbxFirst.Text, TbxLast.Text,
               DropGender.SelectedValue.ToString(), TbxMobile.Text,
                TbxDate.Text);

            Session["p"] = p; // it is saved to be used on the About page

            listOfPeople = (List<Person>)Session["listSession"];
            listOfPeople.Add(p);

            // Clear all inputs by the user
            TbxFirst.Text = "";
            TbxLast.Text = "";
            TbxAge.Text = "";
            TbxDate.Text = "";
            TbxMobile.Text = "";
            DropGender.SelectedIndex = 0;
        }

        // Sets the Calendar visibility true when the LINK BUTTON is clicked
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        // Adds the selected date as a string in the text box
        // Sets the Calendar visibility back to false
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TbxDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
    }
}