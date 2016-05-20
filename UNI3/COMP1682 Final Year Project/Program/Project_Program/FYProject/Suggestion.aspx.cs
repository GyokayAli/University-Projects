using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FYProject
{
    public partial class Suggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string suggest = suggTxtBox.Text;
            string username = Convert.ToString(Session["username"]);

            if (suggest != "")
            {
                try
                {
                    DBConnectivity.SubmitSuggestion(suggest, username);
                    errorLbl.Text = "Your suggestion has been successfully submitted. Thanks a lot!";
                }
                catch (Exception ex)
                {
                    errorLbl.Text = "Oops something went wrong!\nPlease try again later.";
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    suggTxtBox.Text = "";
                }
            }
            else
            {
                errorLbl.Text = "Please fill in the form to submit!";
            }
        }
    }
}