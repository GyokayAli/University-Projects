using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppRestaurantSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //redirect to Member's home page if already logged in
            if (Session["login"] == "true")
            {
                Response.Redirect("./Home");
            }
        }

        protected void logButton_Click(object sender, EventArgs e)
        {
            string email = emailTxtBox.Text; //get email from user input
            string password = passTxtBox.Text; //get password from user input

            //To hash user password
            //Source of solution: http://stackoverflow.com/questions/212510/what-is-the-easiest-way-to-encrypt-a-password-when-i-save-it-to-the-registry
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashPass = System.Text.Encoding.ASCII.GetString(data); //hashed password

            try
            {
                bool isRegistered = DBConnectivity.LoginUser(email, hashPass); //check if user is registered

                if (isRegistered) //yes
                {
                    Session["login"] = "true";
                    Session["email"] = email;
                    Response.Redirect("./Home");
                }
                else //no or something else
                {
                    errorLbl.Text = "Email or Password not correct!";
                }
            }
            catch (Exception ex)
            {
                errorLbl.Text = "Oops something went wrong! Please try again.";
            }
        }
    }
}