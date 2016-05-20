using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class CreateQuestion : System.Web.UI.Page
    {
        // declare global variables
        string str, path;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only the first time the page has been loaded
            if (!Page.IsPostBack)
            {
                // Get data from database to fill dropdownlist of Courses
                CourseDropDown.DataSource = DBConnectivity.LoadCourses();
                CourseDropDown.DataTextField = "courseName";
                CourseDropDown.DataValueField = "courseId";
                CourseDropDown.DataBind();

                // Get data from database to fill dropdownlist of Question Types
                QuestionTypeDrop.DataSource = DBConnectivity.LoadQuestionType();
                QuestionTypeDrop.DataTextField = "type";
                QuestionTypeDrop.DataValueField = "questionTypeId";
                QuestionTypeDrop.DataBind();

                // Get data from database to fill dropdownlist of Test Names
                TestDropDown.DataSource = DBConnectivity.LoadTest();
                TestDropDown.DataTextField = "testName";
                TestDropDown.DataValueField = "testId";
                TestDropDown.DataBind();
            }
        }        

        protected void AddQuestButton_Click(object sender, EventArgs e)
        {
            // OPTIONAL
            // Opens File Uploader and Gets file 
            if (FileUpload1.HasFile)
            {
                // Save Image into server folder
                str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str);
                path = "~//uploads//" + str.ToString(); // holds the file's path in the system

            }
            else { } // else do nothing, because optional
            
            // DB connection that passes 8 parameters and saves them in the "testQuestion" table
            DBConnectivity.AddQuestion(int.Parse(QuestIdBox.Text),QuestionBox.Text,
                int.Parse(TestDropDown.SelectedValue), int.Parse(PointsBox.Text), InstructionBox.Text, path,
                int.Parse(CourseDropDown.SelectedValue), int.Parse(QuestionTypeDrop.SelectedValue));

            // 2nd DB connection that passes 3 parameters and saves them in the "testAnswer" table
            DBConnectivity2.AddQuestionAnswer(Ans1Box.Text,int.Parse(QuestIdBox.Text), CheckBox1.Checked);
            

            // clear content
            Ans1Box.Text = "";
            CheckBox1.Checked = false;
        }

        // Redirects to previous page
        protected void PrevPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateTest.aspx");

        }
    }
}