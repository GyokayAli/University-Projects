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
    public partial class Contribute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logButton_Click(object sender, EventArgs e)
        {
            string username = usernameTxtBox.Text;
            string pass = passTxtBox.Text;

            SqlConnection myConnection = DBConnectivity.GetConnection();
            string myQuery = "SELECT username, pass from prjAdmin where username='" + username + "' AND pass='" + pass + "'";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();           // open conn
                SqlDataReader dr = myCommand.ExecuteReader();

                if (dr.HasRows)
                {
                    Session["admin"] = "true";
                    Session["adminName"] = username;
                    Response.Redirect("./QuestionBank");
                }
                else
                {
                    errorLbl.Text = "Login details not correct!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();        // close conn
            }
        }
    }
}