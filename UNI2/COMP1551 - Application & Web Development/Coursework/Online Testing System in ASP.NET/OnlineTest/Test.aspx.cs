using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class Test : System.Web.UI.Page
    {
        // declare variables
        int counter;
        DateTime dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            dt = Convert.ToDateTime(Session["StartTime"]);
            start.Text = dt.ToString();             // exam start time
            current.Text = DateTime.Now.ToString(); // exam current time/finish time

            // Does the first time the page has been loaded
            if (!Page.IsPostBack)
            {
                id.Text = (String)Session["StudentID"];              // get student id from Session
                name.Text = (String)Session["StudentName"];          // get student name from Session
                course.Text = (String)Session["SelectedCourse"];     // get course name from Session
                testString.Text = (String)Session["SelectedTest"];   // get test name from Session
                number.Text = (String)Session["QuestionNum"];        // get number of questions from Session
                TestNameLabel.Text = (String)Session["SelectedTest"];// sets the Test Title

                // used as index
                counter = 0;
                Session["counter"] = counter;

                // creates a new list of questions with randomized order from Session
                List<Question> testQuestions = (List<Question>)Session["RandomQuestions"];

                // creates a new list of answers of a particular question using 1 param - questionId
                List<QuestionAnswer> questionAnswers = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);

                // displays the points the current question worths in a label
                PointLabel.Text = testQuestions[counter].Point.ToString();

                // displays the question instructions on the top of the question label
                InstructLabel.Text = testQuestions[counter].Instruction;

                // displays the question in a Lable on the top of the radiobuttonlist
                QuestLabel.Text = counter + ". " + testQuestions[counter].QuestionName;
 
                // loads all the answers of particular question from "testAnswer" table using 1 parameter - questinId
                RadioButtonList1.DataSource = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);
                RadioButtonList1.DataTextField = "answerName";
                RadioButtonList1.DataValueField = "answerId";
                RadioButtonList1.DataBind();

                // hides the "Previos" button
                PrevButton.Visible = false;

                // if question doesn't have a picture nothing will be displayed
                string url = testQuestions[counter].Picture;
                if (url == "")
                {
                    Image1.Visible = false;
                }
                else
                {
                    Image1.Visible = true;  // if it has a picture
                    Image1.ImageUrl = url;  // the picture will be displayed
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // just an example exam mark, because I didn't have time to figure out this bit
            int mark = 90;

            // "Previous question" button displayed
            PrevButton.Visible = true;

            counter = int.Parse(Session["counter"].ToString());

            // creates a new list of questions with randomized order from Session
            List<Question> testQuestions = (List<Question>)Session["RandomQuestions"];

            // creates a new list of answers of a particular question using 1 param - questionId
            List<QuestionAnswer> questionAnswers = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);

            // DB connection that saves students answer from each test question
            // using 3 params - answer, questionId, studentId
            DBConnectivity.SaveStudentAnswer(RadioButtonList1.SelectedItem.ToString(), testQuestions[counter].QuestionId, int.Parse(Session["StudentID"].ToString()));

            // increment by 1 every time
            counter += 1;
            Session["counter"] = counter;

            // if counter is bigger than the number of questions available for that particular test
            // the test is finalized and redirected to Results page
            if (counter >= testQuestions.Count)
            {
                DBConnectivity.SaveTestAttempt(dt.ToString(), DateTime.Now.ToString(), int.Parse(Session["SelectedTestId"].ToString()), int.Parse(Session["StudentID"].ToString()), mark);
                Response.Redirect("Results.aspx");
            }
            else
            {
                PointLabel.Text = testQuestions[counter].Point.ToString();
                InstructLabel.Text = testQuestions[counter].Instruction;
                QuestLabel.Text =counter+". " +testQuestions[counter].QuestionName;
            }


            RadioButtonList1.ClearSelection(); // clear radio button user selection
            RadioButtonList1.Items.Clear();    // clear radio buttons' data

            // loads all the answers of particular question from "testAnswer" table using 1 parameter - questinId
            RadioButtonList1.DataSource = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);
            RadioButtonList1.DataTextField = "answerName";
            RadioButtonList1.DataValueField = "answerId";
            RadioButtonList1.DataBind();
        }

        protected void PrevButton_Click(object sender, EventArgs e)
        {
            counter = int.Parse(Session["counter"].ToString());

            // creates a new list of questions with randomized order from Session
            List<Question> testQuestions = (List<Question>)Session["RandomQuestions"];

            // decrement everytime the previous question is requested
            counter -=1;
            Session["counter"] = counter;

            // if counter is bigger than the number of questions available for that particular test
            // the test is finalized and redirected to Results page
            if (counter >= testQuestions.Count)
            {
                Response.Redirect("Student.aspx");
            }
            else
            {
                PointLabel.Text = testQuestions[counter].Point.ToString();
                InstructLabel.Text = testQuestions[counter].Instruction;
                QuestLabel.Text = counter + ". " + testQuestions[counter].QuestionName;
            }

            RadioButtonList1.ClearSelection(); // clear radio button user selection
            RadioButtonList1.Items.Clear();    // clear radio buttons' data

            // loads all the answers of particular question from "testAnswer" table using 1 parameter - questinId
            RadioButtonList1.DataSource = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);
            RadioButtonList1.DataTextField = "answerName";
            RadioButtonList1.DataValueField = "answerId";
            RadioButtonList1.DataBind();
        }       
    }
}