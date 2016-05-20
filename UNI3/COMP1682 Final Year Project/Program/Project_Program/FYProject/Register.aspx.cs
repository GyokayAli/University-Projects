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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == "true")
            {
                Response.Redirect("./Default");
            }
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            //To hash user password
            //Source of solution: http://stackoverflow.com/questions/212510/what-is-the-easiest-way-to-encrypt-a-password-when-i-save-it-to-the-registry
            byte[] data = System.Text.Encoding.ASCII.GetBytes(passTxtBox.Text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashPass = System.Text.Encoding.ASCII.GetString(data); //hashed password

            string username = usernameTxtBox.Text;
            string password = passTxtBox.Text;
            string email = emailTxtBox.Text;
            string confirm = confTxtBox.Text;

            if (password == confirm)
            {
                SqlConnection sqlConn = DBConnectivity.GetConnection();

                SqlCommand sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO prjMember (username,email,pass) VALUES ('" + username + "','" + email + "', '" + hashPass + "');";

                try
                {
                    sqlConn.Open();           // open conn
                    sqlCmd.ExecuteNonQuery();
                    Response.Redirect("./Login");
                }
                catch (Exception ex)
                {
                    errorLbl.Text = "Account creation has failed. User exists!";
                }
                finally
                {
                    sqlConn.Close();        // close conn
                }
            }
        }
    }
}