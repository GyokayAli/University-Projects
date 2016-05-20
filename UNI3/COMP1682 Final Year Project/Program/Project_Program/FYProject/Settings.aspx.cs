using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace FYProject
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }
        }
        protected void settingsButton_Click(object sender, EventArgs e)
        {           
            string newPass = newPassTxtBox.Text;
            string confPass = confPassTxtBox.Text;

            if(newPass == confPass)
            {
                //To hash user password
                //Source of solution: http://stackoverflow.com/questions/212510/what-is-the-easiest-way-to-encrypt-a-password-when-i-save-it-to-the-registry
                byte[] data1 = System.Text.Encoding.ASCII.GetBytes(oldPassTxtBox.Text);
                data1 = new System.Security.Cryptography.SHA256Managed().ComputeHash(data1);
                string oldHashPass = System.Text.Encoding.ASCII.GetString(data1); //old hashed password

                byte[] data2 = System.Text.Encoding.ASCII.GetBytes(newPassTxtBox.Text);
                data2 = new System.Security.Cryptography.SHA256Managed().ComputeHash(data2);
                string newHashPass = System.Text.Encoding.ASCII.GetString(data2); //new hashed password

                SqlConnection sqlConn = getConnection();
                SqlCommand sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "UPDATE prjMember SET pass ='"+ newHashPass +"' WHERE username ='"+ Session["username"] +"' AND pass = '" +oldHashPass+ "'";

                try
                {
                    sqlConn.Open();           // open conn
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    Response.Redirect("./Members");
                    
                }
                catch (Exception ex)
                {
                   Console.WriteLine("Exception in DBHandler", ex);
                }
                finally
                {
                    sqlConn.Close();        // close conn
                }
            }
            else
            {
                erroLbl.Text = "New password does not much!";
            }
        }

        private static SqlConnection getConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }
    }
}