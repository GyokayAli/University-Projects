using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAppRestaurantSystem
{
    public partial class RestaurantDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if logged in, if not redirects to Login page
            if (Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }

            int restID = int.Parse(Request.QueryString["restID"]); //get the Restaurant ID by URL

            DataTable dt = new DataTable();
            dt = DBConnectivity.LoadRestaurantTableByID(restID); //get Data Table with single restaurant's details
            GridView1.DataSource = dt; //first grid view
            GridView1.DataBind();
            GridView2.DataSource = dt; //second grid view
            GridView2.DataBind();
        }
    }
}