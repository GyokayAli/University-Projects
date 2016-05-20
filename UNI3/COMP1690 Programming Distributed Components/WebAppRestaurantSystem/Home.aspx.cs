using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace WebAppRestaurantSystem
{
    public partial class Home : System.Web.UI.Page
    {
        DataTable dt = new DataTable(); // new global DataTable
        protected void Page_Load(object sender, EventArgs e)
        {
            //if not logged in redirect to Login page
            if (Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }

            string postcode = DBConnectivity.GetCustomerPostcode(Session["email"].ToString()); //get postcode of current customer
            int limit = 25; //set limit of results displayed
            dt = DBConnectivity.LoadRestaurantTableByPostcode(postcode, limit); // get DataTable with restaurant records
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string postcode = postcodeTxtBox.Text; //get postcode from user input
            int limit = 25; //set limit of results displayed

            dt = DBConnectivity.LoadRestaurantTableByPostcode(postcode, limit); // get DataTable with restaurant records
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void noticeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./NoticeBoard"); //redirects to Virtual Notice Board page
        }
    }
}