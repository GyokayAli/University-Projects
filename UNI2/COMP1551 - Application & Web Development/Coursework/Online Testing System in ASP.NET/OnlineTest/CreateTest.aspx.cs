using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class CreateTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only the first time the page has been loaded
            if (!Page.IsPostBack)
            {
                // Insert data to dropdownlist of Courses from the database
                CourseDropDown.DataSource = DBConnectivity.LoadCourses();
                CourseDropDown.DataTextField = "courseName";
                CourseDropDown.DataValueField = "courseID";
                CourseDropDown.DataBind();
            }

        }

        // Redirects to previous page
        protected void PreviousPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Staff.aspx");
        }

        // Redirects to next page
        protected void NextPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateQuestion.aspx");
        }

        // Creates the test for particular course with chose number of questions
        protected void CreateTestButton_Click(object sender, EventArgs e)
        {
            string title = TestTitleBox.Text; // Test name
            int questQuantity = int.Parse(TestQuestNoBox.Text); // Number of question to be in the test
            int courseId = int.Parse(CourseDropDown.SelectedValue); // Course id
            
            DBConnectivity.CreateTest(title,questQuantity,courseId); // Saves 3 parameters in the "test" table

            // Redirects to questions page
            Response.Redirect("CreateQuestion.aspx");
        }

       
    }
}