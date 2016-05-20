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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == "true")
            {
                Response.Redirect("./Default");
            }
        }

        protected void logButton_Click(object sender, EventArgs e)
        {
            //To hash user password
            //Source of solution: http://stackoverflow.com/questions/212510/what-is-the-easiest-way-to-encrypt-a-password-when-i-save-it-to-the-registry
            byte[] data = System.Text.Encoding.ASCII.GetBytes(passTxtBox.Text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashPass = System.Text.Encoding.ASCII.GetString(data); //hashed password

            string username = usernameTxtBox.Text;
            Session["username"] = username;

            SqlConnection sqlConn = DBConnectivity.GetConnection();
            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM prjMember WHERE username='" + username + "' AND pass='" + hashPass + "';";

            try
            {
                sqlConn.Open();           // open conn
                SqlDataReader dr = sqlCmd.ExecuteReader();

                if(dr.HasRows)
                {
                    Session["login"] = "true";
                    Response.Redirect("./Members");
                }
                else
                {
                    errorLbl.Text = "Login details not correct!";
                }
            }
            catch (Exception ex)
            {
                errorLbl.Text = "Oops something went wrong!";
            }
            finally
            {
                sqlConn.Close();        // close conn
            }
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Register");
        }
    }
}