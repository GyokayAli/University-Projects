using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppRestaurantSystem
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //logs out the user
            Session["login"] = null; //kill
            Session["email"] = null; //kill
            Response.Redirect("./Default");
        }
    }
}