using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYProject
{
    public partial class Members : System.Web.UI.Page
    {
        int counter2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }
        }

        protected void proceed_Click(object sender, EventArgs e)
        {
          
        }
    }
}