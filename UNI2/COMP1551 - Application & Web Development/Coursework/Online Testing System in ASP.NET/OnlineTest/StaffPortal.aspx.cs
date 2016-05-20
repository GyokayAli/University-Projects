using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class StaffPortal : System.Web.UI.Page
    {
        // declare variable
        string pass;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void passButton_Click1(object sender, EventArgs e)
        {
            // if input is equal to secret word user gets access to Staff's portal
            pass = PassBox.Text;
            if (pass == "admin")
            {   
               Response.Redirect("Staff.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx"); // if not Redirected to home page
            }
            
        }

        
    }
}