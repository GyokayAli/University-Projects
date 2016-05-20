using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace OnlineTest
{
    public partial class Student : System.Web.UI.Page
    {
        // declare variable
        int counter2;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Does only the first time the page has been loaded
            if (!Page.IsPostBack)
            {
                // gets all Courses from the DB and fills the Course dropdownlist
                CourseDropDown.DataSource = DBConnectivity.LoadCourses();
                CourseDropDown.DataTextField = "courseName";
                CourseDropDown.DataValueField = "courseId";
                CourseDropDown.DataBind();

                // gets all Test names from the DB and fills the Test dropdownlist
                TestDropDown.DataSource = DBConnectivity.LoadTest();
                TestDropDown.DataTextField = "testName";
                TestDropDown.DataValueField = "testId";
                TestDropDown.DataBind();

                // to count indexes
                counter2 = 0;
                Session["counter2"] = counter2;               
            }
          
        }

        // Takes to Test page
        protected void ProceedButton_Click(object sender, EventArgs e)
        {   
            // a list that holds the number of questions of the chosen test
            List<Test> currentTest = DBConnectivity2.LoadNumberOfQuestions(int.Parse(TestDropDown.SelectedValue.ToString()));     
      
            // a list that holds all the questions of the chosen test
            List<Question> allQuestions = DBConnectivity.LoadQuestionsByTest(int.Parse(TestDropDown.SelectedValue.ToString()));
   
            Random r = new Random();
            List<Question> randomQuestions = new List<Question>();

            // randomize questions' order and saves them in new list one by one
            while (randomQuestions.Count < currentTest[counter2].TestQuestionQuantity)
            {          
                int num = r.Next(allQuestions.Count);
                bool containsQuestion = false;
                foreach (var quest in randomQuestions)
                {
                    if (allQuestions[num] == quest)
                    {
                        containsQuestion = true;
                    }
                }
                if (!containsQuestion)
                {
                    randomQuestions.Add(allQuestions[num]);
                }

            }
            Session["RandomQuestions"] = randomQuestions; // saves the list of randomized questions in Session

            Session["SelectedTestId"] = TestDropDown.SelectedValue; // testId saved in Session
            Session["SelectedCourse"] = CourseDropDown.SelectedItem.ToString(); // courseName saved in Session
            Session["SelectedTest"] = TestDropDown.SelectedItem.ToString();     // testName saved in Session
            Session["QuestionNum"] = currentTest[counter2].TestQuestionQuantity.ToString(); // number of question in a test saved in Session
            Session["StartTime"] = DateTime.Now.ToString(); // exam start time saved in Session

            // increment by 1 every time
            counter2 += 1;
            Session["counter2"] = counter2;
            
            // if secret key is correct the Test starts
            string  secretKey = SecretBox.Text;
            if (secretKey == "openbook")
            {               
                Response.Redirect("Test.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx"); // if not Redirected to home page
            }        

        }       
    }
}