using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppRestaurantSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user logged in redirects to Member's home page
            if (Session["login"] == "true")
            {
                Response.Redirect("./Home");
            }

            if (!Page.IsPostBack)
            {
                //populate day drop box
                IEnumerable<int> days = Enumerable.Range(1, 31);
                dayDropDown.DataSource = days;
                dayDropDown.DataBind();
                //populate month drop box
                IEnumerable<int> months = Enumerable.Range(1, 12);
                monthDropDown.DataSource = months;
                monthDropDown.DataBind();
                //populate year drop box
                for (int i = 2010; i > 1909; i--)
                {
                    ListItem item = new ListItem(i.ToString(), i.ToString());
                    yearDropDown.Items.Add(item);
                }
            }
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            string email = emailTxtBox.Text; //get email
            string fName = fnameTxtBox.Text; //get first name
            string lName = lnameTxtBox.Text; //get last name
            string password = passTxtBox.Text; //get password
            string conf = confTxtBox.Text; //confirm password
            string gender = genderDropDown.SelectedItem.Text; //get gender
            string dob = "" + dayDropDown.SelectedItem.Text + "-" 
                + monthDropDown.SelectedItem.Text + "-" + yearDropDown.SelectedItem.Text; //get Date of Birth
            string tel = telTxtBox.Text; //get the tel number
            string postcode = postcodeTxtBox.Text; //get postcode
            string address = addressTxtBox.Text; //ger address

            //To hash user password
            //Source of solution: http://stackoverflow.com/questions/212510/what-is-the-easiest-way-to-encrypt-a-password-when-i-save-it-to-the-registry
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashPass = System.Text.Encoding.ASCII.GetString(data); //hashed password

            //if password match
            if (password == conf)
            {
                try
                {
                    //register the user
                    DBConnectivity.RegisterNewUser(email, fName, lName, hashPass, gender, dob, tel, postcode, address);
                    Response.Redirect("./Login"); //if successfull redirect to Login page
                }
                catch (Exception ex)
                {
                    errorLbl.Text = "Account creation has failed. User exists!";
                }
            }
            else
            {
                errorLbl.Text = "Password do not match! Please try again.";
            }
        }
    }
}