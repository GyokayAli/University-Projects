using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAppRestaurantSystem
{
    public partial class NoticeBoard : System.Web.UI.Page
    {

        DataTable dt = new DataTable(); // new global Data Table
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user not logged in redirects to Login page
            if (Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }

            string postcode = DBConnectivity.GetCustomerPostcode(Session["email"].ToString()); //get user's postcode
            int limit = 25; //set limit of displayed results

            dt = DBConnectivity.LoadRestaurantTableByPostcode(postcode,limit); //get Data Table of restaurant records
            ImageList.DataSource = dt;
            ImageList.DataBind();

            ImageList.RepeatColumns = 5; // creates grid max 5 x 5 (due to limit=25)
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string postcode = postcodeTxtBox.Text; //get postcode from user input
            int limit = 25; //set limit of displayed results
            dt = DBConnectivity.LoadRestaurantTableByPostcode(postcode, limit); //get Data Table of restaurant records
            ImageList.DataSource = dt;
            ImageList.DataBind();
        }

        //note: auto postback is set true for dropdown list
        protected void closestDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string postcode = postcodeTxtBox.Text; //get user input
            int limit = 0;

            if (closestDropDown.SelectedItem.Value == "25") //check user choice
            {
                ImageList.RepeatColumns = 5; //grid of max 5 x 5
                limit = 25;
            }
            if (closestDropDown.SelectedItem.Value == "9") //check user choice
            {
                ImageList.RepeatColumns = 3; //grid of max 3 x 3
                limit = 9;
            }

            dt = DBConnectivity.LoadRestaurantTableByPostcode(postcode,limit); //get Data Table of restaurant records
            ImageList.DataSource = dt;
            ImageList.DataBind();
        }

        protected void listBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Home"); //return back to listed view or home page
        }
    }
}