using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    // Student Login Page to Student portal
    public partial class StudentPortal : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Login button
        protected void LoginButton_Click(object sender, EventArgs e)
        {
                string name =StudNameBox.Text;           // gets student name
                string email = StudEmailBox.Text;        // gets student email
                string username = StudUsernameBox.Text;  // gets student username
                string pass = StudPassBox.Text;          // gets student password
                int id = int.Parse(StudIdBox.Text);      // gets student ID

            // saves student details in "student" tablee using 5 params
                DBConnectivity.SaveStudentDetails(id, name, email, username, pass);

                Session["StudentID"] = StudIdBox.Text;     // saves student ID in Session
                Session["StudentName"] = StudNameBox.Text; // saves student name in Session
      
            // Login to portal
            Response.Redirect("Student.aspx");
        }      
    }
}